using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8.2f, 8.2f), transform.position.y);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}
