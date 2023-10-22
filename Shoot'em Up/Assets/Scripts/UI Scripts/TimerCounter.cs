using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerCounter : MonoBehaviour
{
    TextMeshProUGUI timeUI;
    float startTime;
    float ellapsedTime;

    bool startCounter;

    int minutes;
    int seconds;

    void Start()
    {

        StartTimeCounter();

        timeUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(startCounter)
        {
            ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void StopTimeCounter()
    {
        startCounter = false;
    }

    //public void ResetTime()
    //{
    //    if(gameManager.gameTime)
    //    {
    //        gameManager.time += Time.deltaTime;
    //    }

    //    minutes = (int)ellapsedTime / 60;
    //    seconds = (int)ellapsedTime % 60;

    //    timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    //}
}
