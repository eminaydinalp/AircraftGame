using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public bool isCheck;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Debug.Log("CheckPoit Trigger");
            isCheck = true;
            Debug.Log("Bolll ");
        }

        if (!other.CompareTag("UnSuccess")) return;
        if (!isCheck)
        {
            Debug.Log("UnSuccesss Triggered");
        }
        else
        {
            isCheck = false;
        }
    }
}
