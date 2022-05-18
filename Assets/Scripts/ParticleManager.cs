using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private GameObject starParticle;
    public Vector3 starParticlePosition;

    private void OnEnable()
    {
        EventManager.OnTriggerCheckPoint += OpenStarParticle;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerCheckPoint -= OpenStarParticle;
    }

    private void OpenStarParticle()
    {
        starParticle.transform.position = starParticlePosition;
        starParticle.SetActive(true);
        StartCoroutine(InActiveParticle(starParticle, 3f));
    }

    private IEnumerator InActiveParticle(GameObject particle, float time)
    {
        yield return new WaitForSeconds(time);
        particle.SetActive(false);
    }
}