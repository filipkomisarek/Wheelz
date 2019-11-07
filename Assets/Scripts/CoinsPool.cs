using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPool : MonoBehaviour
{
    public int coinsPoolSize = 10;
    public GameObject coinsPrefab;
    public float spawnRate = 1f;
    public float coinsMin = -1f;
    public float coinsMax = 3.5f;

    private GameObject[] coins;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentCoin = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = new GameObject[coinsPoolSize];
        for (int i = 0; i < coinsPoolSize; i++)
        {
            coins[i] = (GameObject)Instantiate(coinsPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(coinsMin, coinsMax);
            coins[currentCoin].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentCoin++;
            if(currentCoin >= coinsPoolSize)
            {
                currentCoin = 0;
            }
        }
    }
}
