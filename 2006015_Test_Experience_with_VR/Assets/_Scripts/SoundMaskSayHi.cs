using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaskSayHi : MonoBehaviour
{
    private AudioSource HiSource;
    public AudioClip[] HiClips;

    // Start is called before the first frame update
    void Start()
    {
        HiSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        Debug.Log("MaskSayHi");
        StartCoroutine(WaitForPlayHi());
    }

    IEnumerator WaitForPlayHi()
    {

        yield return new WaitForSeconds(3);
        PlayRandomSoundHi();
    }

    public void PlayRandomSoundHi()
    {
        int selection = Random.Range(0, HiClips.Length);
        HiSource.PlayOneShot(HiClips[selection]);
    }
}
