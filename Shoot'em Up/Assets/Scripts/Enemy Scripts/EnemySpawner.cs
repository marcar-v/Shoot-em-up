using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    float maxSpawnRateInSeconds = 2f;


    private void Start()
    {
        Invoke("StartEnemySpawn", 2f);
    }
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        GameObject anEnemy = (GameObject)Instantiate(enemy);
        anEnemy.transform.position = new Vector2(Random.Range (min.x,max.x),max.y);

        RateEnemySpawn();
    }

    void RateEnemySpawn()
    {
        float spawnInSeconds;

        if(maxSpawnRateInSeconds > 1) 
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    private void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }
        if(maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }


    public void StartEnemySpawn()
    {
        maxSpawnRateInSeconds = 2f;
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 15f);
    }
    public void StopEnemySpawn()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
}
