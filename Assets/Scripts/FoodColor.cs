using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodColor : MonoBehaviour
{

    private GameObject snakehead;
    // Start is called before the first frame update
    void Awake()
    {
        snakehead = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = snakehead.GetComponent<MeshRenderer>().material.color;
    }
}
