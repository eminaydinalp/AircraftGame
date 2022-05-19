using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;


public class LandingGear : MonoBehaviour
{
    public enum GearState
    {
        Raised = -1,
        Lowered = 1
    }

    // The landing gear can be raised and lowered at differing altitudes.
    // The gear is only lowered when descending, and only raised when climbing.

    // this script detects the raise/lower condition and sets a parameter on
    // the animator to actually play the animation to raise or lower the gear.

    public float raiseAtAltitude = 40;
    public float lowerAtAltitude = 40;
    
    public GearState m_State = GearState.Lowered;
    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private AeroplaneController m_Plane;

    // Use this for initialization
    private void Start()
    {
        m_Plane = GetComponent<AeroplaneController>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        EventManager.OnTriggerLastCheckPoint += Landing;
        EventManager.OnTriggerFinishLine += StopAircraft;
        EventManager.OnGameOver += StopAircraft;
        EventManager.OnGameOver += BoomAircraft;
    }
    private void OnDisable()
    {
        EventManager.OnTriggerLastCheckPoint -= Landing;
        EventManager.OnTriggerFinishLine -= StopAircraft;
        EventManager.OnGameOver -= StopAircraft;
        EventManager.OnGameOver -= BoomAircraft;
    }


    // Update is called once per frame
    private void Update()
    {
        if (m_State == GearState.Lowered && m_Plane.Altitude > raiseAtAltitude && m_Rigidbody.velocity.y > 0)
        {
            m_State = GearState.Raised;
        }

        if (m_State == GearState.Raised && m_Plane.Altitude < lowerAtAltitude && m_Rigidbody.velocity.y < 0)
        {
            m_State = GearState.Lowered;
        }

        // set the parameter on the animator controller to trigger the appropriate animation
        m_Animator.SetInteger("GearState", (int)m_State);
    }

    private void Landing()
    {
        m_Plane.isLanding = true;
        m_Plane.sphereCollider.enabled = true;
        Physics.gravity = Vector3.down * 50f;
        if (m_Plane.maxEngine.value > 80f) m_Plane.maxEngine.value= 80f;
        transform.rotation = Quaternion.Euler(0, 0,0);
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
      
    }

    private void StopAircraft()
    {
        m_Rigidbody.velocity = Vector3.zero;
    }

    private void BoomAircraft()
    {
        transform.DOScale(Vector3.zero, 1.2f).OnComplete(() => gameObject.SetActive(false));
    }
}