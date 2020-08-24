using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounNotificationLevel4 : MonoBehaviour
{
    public AudioClip NotificationLevel4;
    public float Volume;
    AudioSource Level4;
    public bool alreadyPlayedNotificationLevel4 = false;
    // Start is called before the first frame update
    void Start()
    {
        Level4 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitForSound());

    }

    IEnumerator WaitForSound()
    {

        yield return new WaitForSeconds(0);
        PlaySound();
    }

    public void PlaySound()
    {
        if(!alreadyPlayedNotificationLevel4)
        {
            Level4.PlayOneShot(NotificationLevel4, Volume);
            alreadyPlayedNotificationLevel4 = true;
        }
    }
}
