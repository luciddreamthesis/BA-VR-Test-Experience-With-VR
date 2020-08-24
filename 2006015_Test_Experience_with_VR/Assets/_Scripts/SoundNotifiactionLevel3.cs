using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNotifiactionLevel3 : MonoBehaviour
{

    public AudioClip NotificationLevel3;
    public float Volume;
    AudioSource Level3;
    public bool alreadyPlayedNotificationLevel3 = false;
    // Start is called before the first frame update
    void Start()
    {
        Level3 = GetComponent<AudioSource>();
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
        if (!alreadyPlayedNotificationLevel3)
        {
            Level3.PlayOneShot(NotificationLevel3, Volume);
            alreadyPlayedNotificationLevel3 = true;
        }
    }

}
