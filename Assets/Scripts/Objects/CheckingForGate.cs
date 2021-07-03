using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CheckingChange();

public class CheckingForGate : MonoBehaviour
{
    private bool OK = false;

    private event CheckingChange OkChanged;

    public bool IsOK()
    {
        return OK;
    }

    protected void SetOkTo(bool newOK)
    {
        OK = newOK;
        OkChanged.Invoke();
    }

    public void RegisterCheckingEvent(CheckingChange eventChecking)
    {
        OkChanged += eventChecking;
    }
}
