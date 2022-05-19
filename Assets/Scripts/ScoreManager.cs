using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float _score;

    private void OnEnable()
    {
        EventManager.OnTriggerCheckPoint += IncreaseScore;
        EventManager.OnTriggerLastCheckPoint += IncreaseScore;
        EventManager.OnTriggerUnSuccess += DecreaseScore;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerCheckPoint -= IncreaseScore;
        EventManager.OnTriggerLastCheckPoint -= IncreaseScore;
        EventManager.OnTriggerUnSuccess -= DecreaseScore;
    }

    private void IncreaseScore()
    {
        _score += 1;
        scoreText.transform.DOPunchRotation(Vector3.one * 0.5f, 2f);
        scoreText.DOColor(Color.green, 2f).SetInverted(true);
        scoreText.text = "Score : " + _score;
    }
    private void DecreaseScore()
    {
        if(_score <= 0) return;
        _score -= 1;
        scoreText.transform.DOPunchScale(Vector3.one * 0.5f, 2f);
        scoreText.DOColor(Color.red, 2f).SetInverted(true);
        scoreText.text = "Score : " + _score;
    }
}