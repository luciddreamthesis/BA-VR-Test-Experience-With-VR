using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskInteraction : MonoBehaviour
{
  
    //Target Position  for Masks
    public Transform TargetMask1;
    public Transform TargetMask2;
    public Transform TargetMask3;
    public Transform TargetMask4;
    public Transform TargetMask5;
    public Transform TargetMask6;
    public GameObject Mask1;
    public GameObject Mask2;
    public GameObject Mask3;
    public GameObject Mask4;
    public GameObject Mask5;
    public GameObject Mask6;


    public float speed;
    public bool startMoving = false;


    
   
    void OnTriggerEnter(Collider other)
    {
        startMoving = true;
    }

    void Update()
     {
        //Debug.Log("Start moving"+startMoving);
        if (startMoving == true)
        {
            var step = speed * Time.deltaTime;
            //Vector3 startPos = Mask.transform.position;
            //Vector3 endPos = Vector3.MoveTowards(Mask.transform.position, TargetMask.position, step);
            Mask1.transform.position = Vector3.MoveTowards(Mask1.transform.position, TargetMask1.position, step);
            Mask2.transform.position = Vector3.MoveTowards(Mask2.transform.position, TargetMask2.position, step);
            Mask3.transform.position = Vector3.MoveTowards(Mask3.transform.position, TargetMask3.position, step);
            Mask4.transform.position = Vector3.MoveTowards(Mask4.transform.position, TargetMask4.position, step);
            Mask5.transform.position = Vector3.MoveTowards(Mask5.transform.position, TargetMask5.position, step);
            Mask6.transform.position = Vector3.MoveTowards(Mask6.transform.position, TargetMask6.position, step);
            //Debug.Log("Target pos" + TargetMask.position);
            //Debug.Log("Start pos" + Mask.transform.position);
        }

    }
}
