using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
public GameObject Enemy3;
public GameObject Score;

    float maxSpawnRateInSeconds = 8f;

    
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
    }

    
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0.1f));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(5, 0.6f));

        if(Score.GetComponent<Score>().score >= 6000){
        GameObject anEnemy = (GameObject)Instantiate(Enemy3);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

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
