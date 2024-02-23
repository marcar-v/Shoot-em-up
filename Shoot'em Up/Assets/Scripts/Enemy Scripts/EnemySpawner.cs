using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public  GameObject[] enemies;
    [SerializeField] int rows = 2;
    [SerializeField] int columns = 1;
    [SerializeField] float spacing = 0.5f;

    int _enemiesSpawned;
    int _totalEnemiesSpawned = 2;

    private static EnemySpawner _instance;

    public static EnemySpawner instance { get; private set; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Debug.Log("EnemySpawner instanciado");
        }
        else
        {
            Debug.Log("Cuidado, más de un Enemy Spawner en escena.");
        }
    }
    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, 20f);
    }
    public void SpawnEnemies()
    {
        float screenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        float startX = -screenWidth / 10f + spacing / 2.0f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if(_enemiesSpawned < _totalEnemiesSpawned)
                {
                    float x = startX + col * spacing;
                    float y = Camera.main.orthographicSize * 1.1f + (row * spacing);

                    Vector3 spawnPosition = new Vector3(x, y, 0f);

                    int i = Random.Range(0, enemies.Length);
                    Instantiate(enemies[i], spawnPosition, Quaternion.identity);
                }

            }
        }
    }
}
