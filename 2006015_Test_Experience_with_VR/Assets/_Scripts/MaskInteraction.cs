using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskInteraction : MonoBehaviour
{
  
    //Target Position  for Masks
    public Transform TargetMask;
   
    public GameObject Mask;
    public float speed;


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mask");
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetMask.position, step);

    }
}
