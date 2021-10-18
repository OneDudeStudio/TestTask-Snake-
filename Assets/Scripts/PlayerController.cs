using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Movement
    [SerializeField] private float snakeSpeed;
    [SerializeField] private float horizontalSnakeSpeed;
    [SerializeField] private float rangeX ;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Transform pointer;

    //Snake Body Settings
    public Vector3 point;
    public int Gap = 10;
    public int feverMultiplier = 2;
    public GameObject BodyPrefab;
    [SerializeField] private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private CollisionController collisionController;
    private bool hasFever;

    private void Awake()
    {
        AddBodyPart();
        AddBodyPart();
        collisionController = gameObject.GetComponent<CollisionController>();
        Time.timeScale = 1;
        
    }
    
    private void FixedUpdate()
    {
        if (collisionController.isAlive)
        {
            PlayerControll();
            PlayerPlace();
            BodyPartsMovement();
        }
        
        
    }
    //Player movement methods
    public void PlayerPlace()
    {
        if (hasFever == false)
        {
            if (transform.position.x < -rangeX)
            {
                transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rangeX)
            {
                transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
            }
        }
        else if (hasFever == true)
        {
            transform.position = new Vector3(Mathf.MoveTowards(transform.position.x,0,horizontalSnakeSpeed), transform.position.y, transform.position.z);//
        }
        
    }
    public void PlayerControll()
    {
        if (hasFever == false &collisionController.isfinished ==false )
        {
            transform.Translate(Vector3.forward * Time.deltaTime * snakeSpeed);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(camTransform.position, camTransform.forward * 100f, Color.yellow);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    pointer.position = hit.point;
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), horizontalSnakeSpeed);
                }
            }
        }
        else if (hasFever == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * snakeSpeed * feverMultiplier);
        }
        else if (collisionController.isfinished)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * snakeSpeed);
            Invoke("FinishGame", 5f);
        }
        
    }

    //Body Parts Methods
    void BodyPartsMovement()
    {
            PositionsHistory.Insert(0, transform.position - new Vector3(0, 0, 1f));
            int index = 0;
            foreach (var body in BodyParts)
            {
            if (hasFever == false)
            {
                //find point coordinates
                point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];
                // Move body to the point
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * snakeSpeed * Time.deltaTime;
            }
            else
            {
                point = PositionsHistory[Mathf.Clamp(index * (Gap / feverMultiplier), 0, PositionsHistory.Count - 1)];
                Vector3 moveDirection = (point - body.transform.position);
                body.transform.position += moveDirection * snakeSpeed * Time.deltaTime;
            }
                //Rotate body parts
                body.transform.LookAt(point);
                index++;
            }
                
    }
    //Add Body Parts Methods
    public void AddBodyPart()
    {
        GameObject body;
        body = Instantiate(BodyPrefab,new Vector3(point.x, point.y, point.z),Quaternion.identity);
        BodyParts.Add(body);
        
    }

    public void CheckFever()
    {
        hasFever = collisionController.hasFever;
    }
    void FinishGame()
    {
        Time.timeScale = 0;
        
    }

}
