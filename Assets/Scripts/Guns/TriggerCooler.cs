using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCooler
{
    private float CoolDownBetweenTriggers = 1;

    private float TimeSinceLastTrigger = 0;


    public void SetCoolDownTime(float coolDownDuration)
    {
        CoolDownBetweenTriggers = coolDownDuration;
    }


    public void CooldownTrigger()
    {
        if (DoesTriggerNeedCooling())
        {
            ApplyCooling();
        }
    }

    private bool DoesTriggerNeedCooling()
    {
        return TimeSinceLastTrigger < CoolDownBetweenTriggers;
    }

    private void ApplyCooling()
    {
        TimeSinceLastTrigger += Time.deltaTime;
    }


    public bool IsReadyToTrigger()
    {
        return TimeSinceLastTrigger >= CoolDownBetweenTriggers;
    }


    public void ResetTrigger()
    {
        TimeSinceLastTrigger = 0;
    }
}
