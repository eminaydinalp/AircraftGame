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

        if (!other.CompareTag("UnSuccess")) return;
        if (!isCheck)
        {
            Debug.Log("UnSuccesss Triggered");
            EventManager.TriggerUnScuccess();
            EventManager.TriggerUnScuccessName("UnSuccess");
        }
        else
        {
            isCheck = false;
        }
    }
}
