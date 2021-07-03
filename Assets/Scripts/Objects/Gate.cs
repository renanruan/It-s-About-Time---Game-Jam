using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    private CheckingForGate[] CheckingConditions;

    [SerializeField]
    private GameObject GateObject;

    private bool GateIsClose = true;

    private void Start()
    {
        RegisterAllEvents();
    }

    private void RegisterAllEvents()
    {
        foreach(CheckingForGate condition in CheckingConditions)
        {
            condition.RegisterCheckingEvent(CheckAllDependencys);
        }
    }

    private void CheckAllDependencys()
    {
        foreach (CheckingForGate checking in CheckingConditions)
        {
            if(checking.IsOK() == false)
            {
                CloseGate();
                return;
            }
        }

        OpenGate();
    }

    private void OpenGate()
    {
        if (GateIsClose)
        {
            GateIsClose = false;
            GateObject.SetActive(GateIsClose);
        }
    }

    private void CloseGate()
    {
        if (!GateIsClose)
        {
            GateIsClose = true;
            GateObject.SetActive(GateIsClose);
        }
    }
}
