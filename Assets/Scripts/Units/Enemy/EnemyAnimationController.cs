using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour, UnitAnimationControl
{
    [SerializeField]
    private Animator EnemyAnimator;

    [SerializeField]
    private AnimatorOverrideController[] EnemyAnimatorsOverride;


    private event AnimEvent DieEvent;

    public void TurnUnitInto(UnitAge.AgeStage stage)
    {
        EnemyAnimator.runtimeAnimatorController = EnemyAnimatorsOverride[(int)stage];
    }
    public void RegisterDieEvent(AnimEvent DieEvent)
    {
        this.DieEvent += DieEvent;
    }

    public void CallDieEvent()
    {
        DieEvent.Invoke();
    }


}
