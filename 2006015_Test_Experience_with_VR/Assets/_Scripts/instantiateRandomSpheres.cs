using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateRandomSpheres : MonoBehaviour
{
    public GameObject star2;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0;i<1000;i++){
       		GameObject s = GameObject.Instantiate(star2, new Vector3(Random.Range(-50f, 60f), Random.Range(-50f, 200f), Random.Range(-200f, 50f)), Quaternion.identity);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
