using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSubscribe : MonoBehaviour
{
    public GameObject cubeObject;
    //Play one Shot 
    public AudioClip SwitchOnWEbsocket;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayedSwitch = false;
    public bool alreadyPlayedEnjoy = false;

    //play with Delay
    private AudioSource EnjoyRide;
    public AudioClip[] ClipEnjoy;


    void Start ()
    {
        cubeObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        EnjoyRide = gameObject.AddComponent<AudioSource>();

    }

    void OnTriggerEnter (Collider other)
    {
         Debug.Log("Player");
        //Sound Switch on
        cubeObject.SetActive(true);
        StartCoroutine(WaitForPlay());

        //Sound Voice Over

        if (!alreadyPlayedSwitch)
        {
            audio.PlayOneShot(SwitchOnWEbsocket, Volume);
            alreadyPlayedSwitch = true;
        }
    }
    IEnumerator WaitForPlay()
    {
        yield return new WaitForSeconds(5);
        PlaySound();
    }
    public void PlaySound()
    {
        if (!alreadyPlayedEnjoy)
        {
            int selection = Random.Range(0, ClipEnjoy.Length);
            EnjoyRide.PlayOneShot(ClipEnjoy[selection]);
            alreadyPlayedEnjoy = true;
        }
            
    }

}
