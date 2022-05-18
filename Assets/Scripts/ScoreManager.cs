using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float _score;

    private void OnEnable()
    {
        EventManager.OnTriggerCheckPoint += IncreaseScore;
        EventManager.OnTriggerUnSuccess += DecreaseScore;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerCheckPoint -= IncreaseScore;
        EventManager.OnTriggerUnSuccess -= DecreaseScore;
    }

    void IncreaseScore()
    {
        _score += 1;
        scoreText.text = "Score : " + _score;
    }
    void DecreaseScore()
    {
        if(_score <= 0) return;
        _score -= 1;
        scoreText.text = "Score : " + _score;
    }
}