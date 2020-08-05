using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateRandomSpheres : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0;i<1000;i++){
       		GameObject s = GameObject.Instantiate(sphere, new Vector3(Random.Range(600f, 0f), Random.Range(0f, 0f), Random.Range(0f, 0f)), Quaternion.identity);
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
