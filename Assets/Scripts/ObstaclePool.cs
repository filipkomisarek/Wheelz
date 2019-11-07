using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public int obstaclePoolSize = 5;
    public GameObject obstaclePrefab;
    public float spawnRate = 1f;
    public float obstacleMin = 0f;
    public float obstacleMax = 2f;

    private GameObject[] obstacles;
    private Vector2 objectPoolPosition = new Vector2(-10f, -20f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentObstacles = 0;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[obstaclePoolSize];
        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned = 0;
        float spawnYPosition = Random.Range(obstacleMin, obstacleMax);
        obstacles[currentObstacles].transform.position = new Vector2(spawnXPosition, spawnYPosition);
        currentObstacles++;
        if(currentObstacles >= obstaclePoolSize)
        {
            currentObstacles = 0;
        }
    }
}
