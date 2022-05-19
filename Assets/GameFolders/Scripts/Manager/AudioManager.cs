using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    private void OnEnable()
    {
        EventManager.OnTriggerUnSuccess += PlayUnSuccess;
        EventManager.OnGameOver += PlayGameOver;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerUnSuccess -= PlayUnSuccess;
        EventManager.OnGameOver -= PlayGameOver;
    }
    
    private void PlayUnSuccess()
    {
        Play("UnSuccess");
    }

    private void PlayGameOver()
    {
        StartCoroutine(PlayGameOverAsync());
    }

    private IEnumerator PlayGameOverAsync()
    {
        yield return new WaitForSeconds(1f);
        //Play("GameOver");
    }
    private void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Play();
    }
    
}
