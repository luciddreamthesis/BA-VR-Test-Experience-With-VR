using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounNotificationLevel4 : MonoBehaviour
{
    public AudioSource NotificationLevel4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        NotificationLevel4.Play();
    }
}
