using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] TimerCounter timerCounterInstance;
    private float bestTime;


    [Header("Player")]
    [SerializeField] PlayerDamaged playerDamaged;
    [SerializeField] bool isDead;
    [SerializeField] bool gameOver;

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Cuidado, más de un Game Manager en escena.");
        }
    }

}
