using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour, UnitAnimationControl
{
    [Header("Animation Controllers")]

    [SerializeField]
    private Animator PlayerAnimator;

    [SerializeField]
    private AnimatorOverrideController PlayerBabyAnimator;
    [SerializeField]
    private AnimatorOverrideController PlayerYoungAnimator;
    [SerializeField]
    private AnimatorOverrideController PlayerAdultAnimator;
    [SerializeField]
    private AnimatorOverrideController PlayerOldAnimator;


    [Header("Animation Trigger Components")]

    [SerializeField]
    private PlayerMovement PlayerSpeedControl;



    private void Start()
    {
        RegisterSpeedEvent();
        RegisterHurtEvent();
        RegisterDieEvent();
    }

    private void RegisterSpeedEvent()
    {
        PlayerSpeedControl.SpeedChange += OnSpeedChange;
    }

    void OnSpeedChange()
    {
        PlayerAnimator.SetBool("Moving", PlayerSpeedControl.HasSpeed());
    }

    private void RegisterHurtEvent()
    {

    }

    void OnGetHurt()
    {
        PlayerAnimator.SetTrigger("Hurt");
    }

    private void RegisterDieEvent()
    {

    }

    void OnGetDead()
    {
        PlayerAnimator.SetTrigger("Dead");
    }

    public void TurnUnitInto(UnitAge.AgeStage stage)
    {
        switch (stage)
        {
            case UnitAge.AgeStage.Baby:
                TurnBaby();
                break;
            case UnitAge.AgeStage.Young:
                TurnYoung();
                break;
            case UnitAge.AgeStage.Adult:
                TurnAdult();
                break;
            case UnitAge.AgeStage.Old:
                TurnOld();
                break;

        }
    }

    private void TurnBaby()
    {
        PlayerAnimator.runtimeAnimatorController = PlayerBabyAnimator;
    }

    private void TurnYoung()
    {
        PlayerAnimator.runtimeAnimatorController = PlayerYoungAnimator;
    }

    private void TurnAdult()
    {
        PlayerAnimator.runtimeAnimatorController = PlayerAdultAnimator;
    }

    private void TurnOld()
    {
        PlayerAnimator.runtimeAnimatorController = PlayerOldAnimator;
    }



}
