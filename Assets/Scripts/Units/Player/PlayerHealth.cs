using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float MaxHealth;

    [SerializeField]
    private float CurrentHealth = 0;

    public event AnimEvent GotHurt;

    public event AnimEvent GotDead;

    [SerializeField]
    private InGameHPBar HPBar;

    private void Start()
    {
        SetStartingHealth();
    }

    private void SetStartingHealth()
    {
        if (CurrentHealth == 0)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void ChangeHealthBy(float amount)
    {
        ChangeHealth(amount);

        CheckLimits();

        ShowHPBar();

        if (IsChangeHarmfull(amount))
        {
            if (IsDead())
            {
                CallDeadEvent();
            }
            else
            {
                CallHurtEvent();
            }
        }
    }

    private void ChangeHealth(float amount)
    {
        CurrentHealth += amount;
    }

    private void CheckLimits()
    {
        CheckMaxHPLimit();
        CheckMinHPLimit();
    }

    private void CheckMaxHPLimit()
    {
        if (IsOnMaxLimit())
        {
            ReachMaxLimit();
        }
    }

    private bool IsOnMaxLimit()
    {
        return CurrentHealth >= MaxHealth;
    }

    private void ReachMaxLimit()
    {
        CurrentHealth = MaxHealth;
    }

    private void CheckMinHPLimit()
    {
        if (IsOnMinLimit())
        {
            ReachMinLimit();
        }
    }

    private bool IsOnMinLimit()
    {
        return CurrentHealth <= 0;
    }

    private void ReachMinLimit()
    {
        CurrentHealth = 0;
    }

    private void ShowHPBar()
    {
        HPBar.SetHealthBarTo(CurrentHealth / MaxHealth);
    }

    private bool IsChangeHarmfull(float amount)
    {
        return amount < 0;
    }

    private bool IsDead()
    {
        return CurrentHealth == 0;
    }

    private void CallHurtEvent()
    {
        GotHurt.Invoke();
    }

    private void CallDeadEvent()
    {
        GotDead.Invoke();
    }

    public void SetHealthTo(float value)
    {
        CurrentHealth = value;
    }

    public float GetHealth()
    {
        return CurrentHealth;
    }
}
