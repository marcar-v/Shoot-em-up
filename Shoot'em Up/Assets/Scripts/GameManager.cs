using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject enemySpawner;

    [SerializeField] GameObject scoreText;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState gameManagerstate;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerstate = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch(gameManagerstate)
        {
            case GameManagerState.Opening:

                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                scoreText.GetComponent<GameScore>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerDamaged>().Init();

                enemySpawner.GetComponent<EnemySpawner>().StartEnemySpawn();

                break;

            case GameManagerState.GameOver:

                Invoke("ChangeToOpeningState", 5f);

                enemySpawner.GetComponent<EnemySpawner>().StopEnemySpawn();
                break;

        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        gameManagerstate = state;
        UpdateGameManagerState();
    }

    public void StartGame()
    {
        gameManagerstate = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
