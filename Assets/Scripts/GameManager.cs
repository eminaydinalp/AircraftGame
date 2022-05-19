using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject  winUI, gameOver, startPanel;
    public bool isFinish;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        EventManager.OnTriggerFinishLine += Win;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerFinishLine -= Win;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFinish)
        {
            startPanel.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    
    public void Fail()
    {
        isFinish = true;
        StartCoroutine(nameof(GameOver));
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(.1f);
        gameOver.SetActive(true);
        winUI.SetActive(false);
    }
    
    public void Win()
    {
        isFinish = true;
        StartCoroutine(nameof(CompleteLevel));
    }
    

    public IEnumerator CompleteLevel()
    {
        yield return new WaitForSeconds(0.1f);
        winUI.SetActive(true);
        gameOver.SetActive(false);
    }
}
