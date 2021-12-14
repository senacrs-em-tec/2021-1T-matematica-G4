using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public GameObject Score;
    public GameObject Enemy1;

    float maxSpawnRateInSeconds = 2f;

    
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
    }

    


    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0.1f, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.9f, 1));

        GameObject anEnemy = (GameObject)Instantiate(Enemy1);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInNSeconds = 1f;

        Invoke("SpawnEnemy", spawnInNSeconds);
    }
}


