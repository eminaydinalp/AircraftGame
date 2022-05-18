using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnTriggerCheckPoint;
    public static Action OnTriggerUnSuccess;
    public static Action<string> OnTriggerUnSuccessName;
    public static Action OnTriggerLastCheckPoint;
    public static Action OnTriggerFinishLine;
    public static Action OnMoveAwayMap;

    public static void TriggerCheckPoint()
    {
        OnTriggerCheckPoint?.Invoke();
    }
    
    public static void TriggerUnScuccess()
    {
        OnTriggerUnSuccess?.Invoke();
    }
    public static void TriggerUnScuccessName(string name)
    {
        OnTriggerUnSuccessName?.Invoke(name);
    }
    public static void TriggerLastChecPoint()
    {
        OnTriggerLastCheckPoint?.Invoke();
    }
    public static void TriggerFinishLine()
    {
        OnTriggerFinishLine?.Invoke();
    }
    public static void MoveAwayFromMap()
    {
        OnMoveAwayMap?.Invoke();
    }
}
