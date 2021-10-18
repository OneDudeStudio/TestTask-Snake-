using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamFollow : MonoBehaviour
{
    public Transform player;
    private CollisionController collisionController;
    public Vector3 offset;
    public float delay;
    public bool camIsReady = false;
    private void Start()
    {
        collisionController = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<CollisionController>();
        Invoke("FindSnake", delay);
    }
    private void LateUpdate()
    {
        if (collisionController.isAlive)
        {
            FollowSnake();
        }
        
       // Debug.Log(snakeHead);
    }

    void FindSnake()
    {
        player = GameObject.Find("SnakeHead").transform;
        camIsReady = true;
    }
    void FollowSnake()
    {
        if (camIsReady == true & collisionController.isAlive & collisionController.isfinished == false)
        {
            transform.position = new Vector3(0, 0, player.position.z) + offset;
        }
        else transform.position = transform.position; 
        
    }
}
