using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WarningMoveAway : MonoBehaviour
{
    [SerializeField] private Text warningText;
    [SerializeField] private Text restartText;
    [SerializeField] private Text counterText;

    private bool _isExitMap;
    private float _time;
    [SerializeField] private float moveAwayTime = 5f;
    [SerializeField] private float duration = 5f;

    private void Update()
    {
        if(GameManager.Instance.isFinish) return;
        
        if (_isExitMap)
        {
            _time += Time.deltaTime;
        }

        if (_time > moveAwayTime)
        {
            restartText.gameObject.SetActive(true);
            duration -= Time.deltaTime;
            counterText.text = Mathf.FloorToInt(duration).ToString();
        }

        if (duration <= 0)
        {
            counterText.text = "";
            warningText.gameObject.SetActive(false);
            restartText.gameObject.SetActive(false);
            EventManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isExitMap = false;
            warningText.gameObject.SetActive(false);
            restartText.gameObject.SetActive(false);
            counterText.text = "";
            _time = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isExitMap = true;
            warningText.gameObject.SetActive(true);
            warningText.DOFade(0.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        }
    }
}
