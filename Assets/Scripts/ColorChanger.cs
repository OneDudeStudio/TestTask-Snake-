using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private GameObject[] changecolorLines;
    GameObject closestLine;
    public string nearest;
    private MeshRenderer lineColor;


    private MeshRenderer headColor;
    private MeshRenderer bodyColor;
    private CollisionController collisionController;

    

    private void Start()
    {
        
        collisionController = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<CollisionController>();
        changecolorLines = GameObject.FindGameObjectsWithTag("ColorChanger");//
        //////////////////////
        bodyColor = GetComponent<MeshRenderer>();
        headColor = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
        bodyColor.material.color = headColor.material.color;
    }
    public void ChangeColor()
    {
       lineColor = closestLine.GetComponent<MeshRenderer>();//
       GetComponent<MeshRenderer>().material.color = lineColor.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorChanger"))
        {
            //определить ближайшего
            FindClosestLine();
            ChangeColor();
            Debug.Log("Change color to" + lineColor.material.color);

        }

    }

    GameObject FindClosestLine()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in changecolorLines)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closestLine = go;
                distance = curDistance;
            }
        }
        return closestLine;
    }

    private void Update()
    {
        if (collisionController.isAlive ==false)
        {
            changeColorToRed();
        }
    }
    public void changeColorToRed()
    {
        headColor.material.color = Color.red;
        bodyColor.material.color = Color.red;
       
    }

    

}
