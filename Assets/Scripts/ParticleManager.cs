using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject starParticle;
    [SerializeField] private GameObject winParticle;
    public Vector3 starParticlePosition;

    private void OnEnable()
    {
        EventManager.OnTriggerCheckPoint += OpenStarParticle;
        EventManager.OnTriggerFinishLine += OpenWinParticle;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerCheckPoint -= OpenStarParticle;
        EventManager.OnTriggerFinishLine -= OpenWinParticle;
    }

    private void OpenStarParticle()
    {
        starParticle.transform.position = starParticlePosition + Vector3.forward * 30f;
        starParticle.SetActive(true);
        StartCoroutine(InActiveParticle(starParticle, 3f));
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
}