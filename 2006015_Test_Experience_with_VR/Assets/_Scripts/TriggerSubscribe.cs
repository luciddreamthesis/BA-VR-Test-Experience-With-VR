using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSubscribe : MonoBehaviour
{
    public GameObject cubeObject;
    //public bool activateme;

    void Start ()
    {
        cubeObject.SetActive(false);
        
    }

    void OnTriggerEnter (Collider other)
    {
      
            Debug.Log("Player");
        cubeObject.SetActive(true);
    }
}
