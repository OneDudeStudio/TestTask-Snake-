using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColor : MonoBehaviour
{
    private MeshRenderer headColor;
    private MeshRenderer bodyColor;
    

    private void Start()
    {
        bodyColor = GetComponent<MeshRenderer>();
        headColor = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
        bodyColor.material.color = headColor.material.color;
    }
    
}
