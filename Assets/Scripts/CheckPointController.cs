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
            EventManager.TriggerCheckPoint();
            EventManager.TriggerLastCheckPoint();
        }

        if (!other.CompareTag("UnSuccess")) return;
        if (!isCheck)
        {
            Debug.Log("UnSuccesss Triggered");
            EventManager.TriggerUnSucccess();
            EventManager.TriggerUnSucccessName("UnSuccess");
        }
        else
        {
            isCheck = false;
        }
    }
}
