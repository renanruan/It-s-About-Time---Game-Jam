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


    [Header("Animation Trigger Stats")]

    [SerializeField]
    private PlayerMovement PlayerSpeedControl;

    [SerializeField]
    private PlayerHealth PlayerHealthControl;


    [Header("Components to Manipulate During Animation")]

    [SerializeField]
    private MonoBehaviour[] ComponentsToLock;

    private event AnimEvent DieEvent;

    private void Start()
    {
        RegisterSpeedEvent();
        RegisterHurtEvent();
        RegisterDeathEvent();
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
        PlayerHealthControl.GotHurt += OnGetHurt;
    }

    void OnGetHurt()
    {
        PlayerAnimator.SetTrigger("Hurt");
    }

    private void RegisterDeathEvent()
    {
        PlayerHealthControl.GotDead += OnGetDead;
    }

    void OnGetDead()
    {
        PlayerAnimator.SetTrigger("Dead");
    }

    public void RegisterDieEvent()
    {
        this.DieEvent += OnDie;
    }

    public void OnDie()
    {

    }

    public void TurnUnitInto(UnitAge.AgeStage stage)
    {
        switch (stage)
        {
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


    public void RegisterDieEvent(AnimEvent DieEvent)
    {
        this.DieEvent += DieEvent;
    }

    public void CallDieEvent()
    {
        DieEvent.Invoke();
    }

    public void LockComponents()
    {
        foreach(MonoBehaviour component in ComponentsToLock)
        {
            component.enabled = false;
        }
    }

    public void UnlockComponents()
    {
        gameObject.tag = "Player";
        foreach (MonoBehaviour component in ComponentsToLock)
        {
            component.enabled = true;
        }
    }

    public void RestartLevel()
    {
        LevelTransitioner.RestartScene();
    }

}
