using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNotificationLevel2 : MonoBehaviour
{
    public AudioClip NotificationLevel2;
    public float Volume;
    AudioSource Level2;
    public bool alreadyPlayedNotificationLevel2 = false;
    // Start is called before the first frame update


    void Start()
    {
        Level2 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {

        yield return new WaitForSeconds(5);
        PlaySound();
    }

    public void PlaySound()
    {
        if (!alreadyPlayedNotificationLevel2)
        {
            Level2.PlayOneShot(NotificationLevel2, Volume);
            alreadyPlayedNotificationLevel2 = true;
        }
    }

     
}
