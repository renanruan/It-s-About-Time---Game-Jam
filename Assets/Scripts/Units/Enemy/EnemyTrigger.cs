using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private TriggerCooler GunTrigger;

    [SerializeField]
    private EnemyGunBarrel GunBarrel;

    [SerializeField]
    private EnemyEyeSeeker EyeSeeker;

    [SerializeField]
    private Animator EnemyAnimator;

    [SerializeField]
    private float IntervalBetweenShots = 1;

    private Vector2? PlayerPosition = null;


    private void Start()
    {
        CreateGunTrigger();
        RegisterEyeSeeker();
    }

    void CreateGunTrigger()
    {
        GunTrigger = new TriggerCooler();
        GunTrigger.SetCoolDownTime(IntervalBetweenShots);
    }

    private void RegisterEyeSeeker()
    {
        EyeSeeker.RegisterSeekEvent(SeePlayer);
    }

    private void SeePlayer(Transform playerBody)
    {
        if (playerBody != null)
            PlayerPosition = playerBody.position;
        else
            PlayerPosition = null;
    }

    void Update()
    {
        CoolDownTrigger();

        if (IsTriggerReady() && CanSeePlayer())
        {
            PullGunTrigger();
        }
    }

    private void CoolDownTrigger()
    {
        GunTrigger.CooldownTrigger();
    }

    private bool IsTriggerReady()
    {
        return GunTrigger.IsReadyToTrigger();
    }

    private bool CanSeePlayer()
    {
        return PlayerPosition != null;
    }

    private void PullGunTrigger()
    {
        FiretBarrelAnimation();
        ResetTrigger();
    }

    private void FiretBarrelAnimation()
    {
        EnemyAnimator.SetTrigger("Fire");
    }

    private void ResetTrigger()
    {
        GunTrigger.ResetTrigger();
    }

    private void FiretBarrel()
    {
        GunBarrel.Fire((Vector2)PlayerPosition);
    }
}
