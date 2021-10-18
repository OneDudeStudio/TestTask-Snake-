using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class ParticleColor : MonoBehaviour
{
    
    [SerializeField] GameObject line;


    private void Start()
        
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = line.GetComponent<MeshRenderer>().material.color;
    }
}
