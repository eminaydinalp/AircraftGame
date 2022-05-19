using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject starParticle;
    [SerializeField] private GameObject starParticleLast;
    [SerializeField] private GameObject winParticle;
    [SerializeField] private GameObject failParticle;
    public Vector3 starParticlePosition;

    private void OnEnable()
    {
        EventManager.OnTriggerCheckPoint += OpenStarParticle;
        EventManager.OnTriggerLastCheckPoint += OpenStarParticleLast;
        EventManager.OnTriggerFinishLine += OpenWinParticle;
        EventManager.OnGameOver += OpenGameOverParticle;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerCheckPoint -= OpenStarParticle;
        EventManager.OnTriggerLastCheckPoint -= OpenStarParticleLast;
        EventManager.OnTriggerFinishLine -= OpenWinParticle;
        EventManager.OnGameOver -= OpenGameOverParticle;
    }

    private void OpenStarParticle()
    {
        starParticle.SetActive(true);
        starParticle.transform.position = starParticlePosition + Vector3.forward * 30f;
        StartCoroutine(InActiveParticle(starParticle, 3f));
    }
    private void OpenStarParticleLast()
    {
        if (starParticleLast == null) return;
        starParticleLast.SetActive(true);
        starParticleLast.transform.position = starParticlePosition + Vector3.forward * 30f;
        StartCoroutine(InActiveParticle(starParticleLast, 3f));
    }

    private IEnumerator InActiveParticle(GameObject particle, float time)
    {
        yield return new WaitForSeconds(time);
        particle.SetActive(false);
    }

    private void OpenWinParticle()
    {
        winParticle.SetActive(true);
    }

    private void OpenGameOverParticle()
    {
        StartCoroutine(OpenGameOverParticleAsync());
    }

    private IEnumerator OpenGameOverParticleAsync()
    {
        yield return new WaitForSeconds(.5f);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            failParticle.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        failParticle.SetActive(true);
        StartCoroutine(InActiveParticle(failParticle, 3f));
    }
}