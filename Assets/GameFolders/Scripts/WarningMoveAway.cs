using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WarningMoveAway : MonoBehaviour
{
    [SerializeField] private Text warningText;
    [SerializeField] private Text restartText;

    private bool _isExitMap;
    private float _time;
    private float _moveAwayTime = 10f;

    private void Update()
    {
        if (_isExitMap)
        {
            _time += Time.deltaTime;
        }

        if (_time > _moveAwayTime)
        {
            restartText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isExitMap = false;
            warningText.gameObject.SetActive(false);
            restartText.gameObject.SetActive(false);
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
