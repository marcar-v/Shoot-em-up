using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int score;

    public int Score { 
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    
    }

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreText.text = scoreStr;
    }
}
