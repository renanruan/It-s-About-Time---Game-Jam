using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAge : MonoBehaviour, Ageable
{
    public enum AgeStage {Young, Adult, Old};

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

    void Awake()
    {
        CreateMyAge(); 
    }

    void Start()
    {
        ConfigUnitAnimation();

        RegisterAgeStageEvent(EnterAgeStage);
        RegisterMaxAgeLimitEvent(OnMaxAgeReach);
        RegisterMinAgeLimitEvent(OnMinAgeReach);

        ConfigAgeBar();


    }

    private void CreateMyAge()
    {
        MyAge = new Age(StartingAge, MinAge, MaxAge, AgeStages.Length);
    }

    public void RegisterAgeStageEvent(EnteredNewStage onEnterStage)
    {
        MyAge.RegisterEnteredStageEnvet(onEnterStage);
    }

    private void EnterAgeStage(AgeStage stage)
    {
        UnitAnimation.TurnUnitInto((AgeStage)stage);

        CurrentStage = stage;
    }

    public void RegisterMaxAgeLimitEvent(AgeLimitReached ageLimitEvent)
    {
        MyAge.MaxLimitReached += ageLimitEvent;
    }

    public void RegisterMinAgeLimitEvent(AgeLimitReached ageLimitEvent)
    {
        MyAge.MinLimitReached += ageLimitEvent;
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

    public void SetAgeTo(float newValue)
    {
        ChangeMyAgeValue(newValue - MyAge.GetCurrentAge());
        ChangeBarAgeValue();
    }

    public void ChangeAgeBy(float deltaChange)
    {
        ChangeMyAgeValue(deltaChange);
        ChangeBarAgeValue();
    }

    public bool CanAgeAmount(float deltaAmount)
    {
        if(deltaAmount > 0)
        {
            if (MyAge.GetCurrentAge() < MaxAge - 1)
            {
                return true;
            }
        }
        else if(deltaAmount < 0)
        {
            if (MyAge.GetCurrentAge() > MinAge)
            {
                return true;
            }
        }

        return false;
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

    public float GetAge()
    {
        return MyAge.GetCurrentAge();
    }
}
