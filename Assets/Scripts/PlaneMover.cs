using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    private Vector3 startPosition;
   // private float repeatWidth;
    public float planeSpeed = -40.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < startPosition.z - 150 )
        {
            transform.position = startPosition;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * planeSpeed);
    }
}
