using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemysDead : CheckingForGate
{

    [SerializeField]
    private UnitAge[] EnemyList;

    private int EnemysAlive;

    private void Start()
    {
        RegisterAllEvents();
        CountEnemys();
        SetOkTo(false);
    }

    private void RegisterAllEvents()
    {
        foreach(UnitAge enemy in EnemyList)
        {
            RegisterEnemyDeath(enemy);
        }
    }

    private void RegisterEnemyDeath(UnitAge enemy)
    {
        enemy.RegisterMaxAgeLimitEvent(OnEnemyDeath);
        enemy.RegisterMinAgeLimitEvent(OnEnemyDeath);
    }

    private void CountEnemys()
    {
        EnemysAlive = EnemyList.Length;
    }

    private void OnEnemyDeath()
    {
        EnemysAlive--;

        if(EnemysAlive == 0)
        {
            SetOkTo(true);
        }
    }



}
