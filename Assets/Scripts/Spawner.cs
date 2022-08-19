using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float timeToSpawn = 3f;
    float minimumInterval = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", timeToSpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8.2f, 8.2f), transform.position.y);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Invoke("SpawnEnemy", timeToSpawn);
        if (timeToSpawn > minimumInterval)
        {
            timeToSpawn -= 0.02f;
        }

    }

}
