using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AgeLimitReached();

public delegate void EnteredNewStage(UnitAge.AgeStage stageId);

public class Age
{
    private float CurrentAge = 0;

    private int MinAge = 0;
    private int MaxAge = 0;

    public event AgeLimitReached MaxLimitReached;
    public event AgeLimitReached MinLimitReached;

    private AgeRanges MyStages;

    public event EnteredNewStage EnteredStage;

    public Age(int startingAge, int minAge, int maxAge, int stages)
    {
        CurrentAge = startingAge;

        MinAge = minAge;
        MaxAge = maxAge - 1;

        CreateMyStages(stages);
    }

    private void CreateMyStages(int numStages)
    {
        MyStages = new AgeRanges(MinAge, MaxAge + 1, numStages, (int)CurrentAge);
    }

    public void ChangeAgeBy(float amount)
    {
        ApplyAgeChange(amount);
        CheckAgeLimits();
        CheckAgeStage();
    }

    private void ApplyAgeChange(float amount)
    {
        CurrentAge += amount;
    }

    private void CheckAgeLimits()
    {
        CheckMaxAgeLimit();
        CheckMinAgeLimit();
    }

    private void CheckMaxAgeLimit()
    {
        if(IsOnMaxLimit())
        {
            ReachMaxLimit();
        }
    }

    private bool IsOnMaxLimit()
    {
        return CurrentAge >= MaxAge;
    }

    private void ReachMaxLimit()
    {
        MaxLimitReached.Invoke();
        CurrentAge = MaxAge;
    }

    private void CheckMinAgeLimit()
    {
        if (IsOnMinLimit())
        {
            ReachMinLimit();
        }
    }

    private bool IsOnMinLimit()
    {
        return CurrentAge <= MinAge;
    }

    private void ReachMinLimit()
    {
        MinLimitReached();
        CurrentAge = MinAge;
    }

    private void CheckAgeStage()
    {
        if(MyStages.DoesChangeStateForAge((int)CurrentAge))
        {
            EnteredStage?.Invoke(MyStages.GetStage());
        }
    }

    public void RegisterEnteredStageEnvet(EnteredNewStage functionCall)
    {
        EnteredStage += functionCall;
        EnteredStage.Invoke(MyStages.GetStage());
    }


    public float GetCurrentAge()
    {
        return CurrentAge;
    }

}
