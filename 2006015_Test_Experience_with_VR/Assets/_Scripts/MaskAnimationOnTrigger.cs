using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskAnimationOnTrigger : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    [SerializeField] private Animator myAnimationControllerFront;
    [SerializeField] private Animator myAnimationControllerR;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
            Debug.Log ("Mask animate");
            myAnimationController.SetBool("playAnimation", true);
            myAnimationControllerFront.SetBool("playAnimationFront", true);
            myAnimationControllerR.SetBool("playAnimationRight", true);

    }
}
