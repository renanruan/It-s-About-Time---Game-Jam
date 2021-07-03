using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAge : MonoBehaviour, Ageable
{
    public enum AgeStage { Baby, Young, Adult, Old};

    [SerializeField]
    private int StartingAge;

    [Header("Age Limits")]
    [SerializeField]
    private int MaxAge;
    [SerializeField]
    private int MinAge;
    [SerializeField]
    private AgeStage[] AgeStages;

    private Age MyAge;

    [SerializeField]
    private InGameBar AgeBar;

    private UnitAnimationControl UnitAnimation;

    [SerializeField]
    private AgeStage CurrentStage;

    void Start()
    {
        CreateMyAge();
        RegisterAgeStageEvent();
        RegisterMaxAgeLimitEvent();
        RegisterMinAgeLimitEvent();

        ConfigAgeBar();

        ConfigUnitAnimation();
        
    }

    private void CreateMyAge()
    {
        MyAge = new Age(StartingAge, MinAge, MaxAge, AgeStages.Length);
    }

    private void RegisterAgeStageEvent()
    {
        MyAge.EnteredStage += EnterAgeStage;
    }

    private void EnterAgeStage(AgeStage stage)
    {
        UnitAnimation.TurnUnitInto((AgeStage)stage);

        CurrentStage = stage;
    }

    private void RegisterMaxAgeLimitEvent()
    {
        MyAge.MaxLimitReached += OnMaxAgeReach;
    }

    private void RegisterMinAgeLimitEvent()
    {
        MyAge.MinLimitReached += OnMinAgeReach;
    }

    private void OnMaxAgeReach()
    {

    }

    private void OnMinAgeReach()
    {

    }

    private void ConfigAgeBar()
    {
        AgeBar.SetMinMaxValue(MinAge, MaxAge);
    }

    private void ConfigUnitAnimation()
    {
        UnitAnimation = GetComponent<UnitAnimationControl>();
    }



    public void ChangeAge(float deltaChange)
    {
        ChangeMyAgeValue(deltaChange);
        ChangeBarAgeValue();
    }

    private void ChangeMyAgeValue(float deltaChange)
    {
        MyAge.ChangeAgeBy(deltaChange);
    }

    private void ChangeBarAgeValue()
    {
        AgeBar.SetMarkerPosition(MyAge.GetCurrentAge());
    }

    public AgeStage GetStageAge()
    {
        return CurrentStage;
    }
}
