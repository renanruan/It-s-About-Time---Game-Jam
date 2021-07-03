using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunTrigger : MonoBehaviour
{
    private TriggerCooler GunTrigger;

    [SerializeField]
    private PlayerGunBarrel YoungGunBarrel;

    [SerializeField]
    private PlayerGunBarrel OldGunBarrel;

    [SerializeField]
    private float IntervalBetweenShots = 1;


    private bool YoungShotClick;

    private bool OldShotClick;



    private void Start()
    {
        CreateGunTrigger();
    }

    void CreateGunTrigger()
    {
        GunTrigger = new TriggerCooler();
        GunTrigger.SetCoolDownTime(IntervalBetweenShots);
    }


    void Update()
    {
        CoolDownTrigger();

        CaptureMouseClicks();

        if (IsTriggerReady() && MouseHasClicked())
        {
            PullGunTrigger();
        }
    }

    private void CoolDownTrigger()
    {
        GunTrigger.CooldownTrigger();
    }

    private void CaptureMouseClicks()
    {
        YoungShotClick = Input.GetMouseButton(0);
        OldShotClick = Input.GetMouseButton(1);
    }

    private bool MouseHasClicked()
    {
        return YoungShotClick  || OldShotClick;
    }

    private bool IsTriggerReady()
    {
        return GunTrigger.IsReadyToTrigger();
    }

    private void PullGunTrigger()
    {
        FireCorrectBarrel();
        ResetTrigger();
    }

    private void FireCorrectBarrel()
    {
        if (YoungShotClick)
        {
            YoungGunBarrel.Fire();
        }
        else
        {
            OldGunBarrel.Fire();
        }
    }

    private void ResetTrigger()
    {
        GunTrigger.ResetTrigger();
    }
}
