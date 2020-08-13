using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Transperancy : MonoBehaviour
{
    public GameObject currenGameObject;
    public float alpha = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        currenGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAlpha(currenGameObject.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
