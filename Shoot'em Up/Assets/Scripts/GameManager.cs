using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int rows = 3;
    [SerializeField] int columns = 8;
    [SerializeField] float spacing = 1.05f;

    private static GameManager _instance;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            Debug.Log("GameManager instanciado");
        }
        else
        {
            Debug.Log("Cuidado, más de un Game Manager en escena.");
        }
    }
    private void Start()
    {
        InvokeRepeating("SpawnEnemies", 0f, 25f);
    }
    public void SpawnEnemies()
    {
        float screenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        float startX = -screenWidth / 6.0f + spacing / 2.0f;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = startX + col * spacing;
                float y = Camera.main.orthographicSize * 1.1f + (row * spacing);
                 
                Vector3 spawnPosition = new Vector3(x, y, 0f);

                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
