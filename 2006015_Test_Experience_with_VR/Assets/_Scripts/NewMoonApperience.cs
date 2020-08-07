using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoonApperience : MonoBehaviour
{
    public GameObject moonObject;
    public AudioSource NotificationLevel2;
 

    //public bool activateme;

    void Start()
    {
        moonObject.SetActive(false);
        

    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Moon");
        moonObject.SetActive(true);

        NotificationLevel2.Play();
        

    }
}

