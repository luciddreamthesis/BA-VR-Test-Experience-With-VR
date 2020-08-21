using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundNotificationLevel2 : MonoBehaviour
{
   
    public AudioSource NotificationLevel2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        NotificationLevel2.Play();
    }
}
