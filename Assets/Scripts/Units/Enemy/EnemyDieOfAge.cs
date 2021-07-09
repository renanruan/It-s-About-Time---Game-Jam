using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieOfAge : MonoBehaviour
{
    [SerializeField]
    private UnitAge EnemyAge;

    [SerializeField]
    private Animator EnemyAnimator;

    void Start()
    {
        RegisterDeathEvent();
    }

    void RegisterDeathEvent()
    {
        EnemyAge.RegisterMaxAgeLimitEvent(DieOfAge);
        EnemyAge.RegisterMinAgeLimitEvent(DieOfAge);
    }

    private void DieOfAge()
    {
        EnemyAnimator.SetTrigger("Die");
    }
}
