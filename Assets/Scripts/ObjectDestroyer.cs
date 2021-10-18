using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    private PlayerController playercontroller;
    public GameObject snakeHead;
    private int counter = 0;
    private void Start()
    {
        playercontroller = snakeHead.GetComponent<PlayerController>();
    }

    private void Update()
    {
        Debug.Log(counter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && counter>=10)
        {
            playercontroller.AddBodyPart();
            Destroy(gameObject);
            print("DESTROY");
        }
        else if(other.gameObject.CompareTag("Player") && counter <= 10)
        {
            counter++;
            Destroy(gameObject);
            
        }
        
    }
}
