using System;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private ParticleManager particleManager;
    public bool isCheck;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Debug.Log("CheckPoit Trigger");
            isCheck = true;
            particleManager.starParticlePosition = other.transform.position;
            EventManager.TriggerCheckPoint();
        }

        if (other.CompareTag("LastCheckPoint"))
        {
            isCheck = true;
            particleManager.starParticlePosition = other.transform.position;
            EventManager.TriggerLastCheckPoint();
        }

        if (other.CompareTag("UnSuccess") && !isCheck)
        {
            Debug.Log("UnSuccesss Triggered");
            EventManager.TriggerUnSucccess();
        }

        if (other.CompareTag("GameOver") && !isCheck)
        {
            Debug.Log("Game Over");
            EventManager.GameOver();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnSuccess"))
        {
            isCheck = false;
        }
    }
}