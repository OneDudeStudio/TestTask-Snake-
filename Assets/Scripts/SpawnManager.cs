using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public GameObject[] objectPrefabs;
    public int foodindex;
    public int objectindex;
    public float foodSpawnRangeX;

    private void Start()
    {
        InvokeRepeating("SpawnFood", 2f, 2f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objectPrefabs[objectindex], transform.position, objectPrefabs[objectindex].transform.rotation);
        }
    }


    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-foodSpawnRangeX, foodSpawnRangeX), transform.position.y, transform.position.z);
        foodindex = Random.Range(0, foodPrefabs.Length);
        Instantiate(foodPrefabs[foodindex], spawnPosition, foodPrefabs[foodindex].transform.rotation);
    }
}
