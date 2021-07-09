using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UnitMovement
{
    [Header("Player Movement Parameters")]
    [SerializeField]
    private PlayerAgeAttributes[] Attributes;

    [SerializeField]
    private UnitAge PlayerAge;

    [SerializeField]
    private float MaxVerticalSpeed = 1;
    [SerializeField]
    private float MaxHorizontalSpeed = 1;

    public event AnimEvent SpeedChange;

    private void Start()
    {
        StartUnitMoviment();
        RegisterOnAgeChange();
        
    }

    private void RegisterOnAgeChange()
    {
        PlayerAge.RegisterAgeStageEvent(SetAttribute);
    }

    private void SetAttribute(UnitAge.AgeStage stage)
    {
        PlayerAgeAttributes attributes = Attributes[(int)stage];

        MaxHorizontalSpeed = attributes.MaxHorizontalSpeed;
        MaxVerticalSpeed = attributes.MaxVerticalSpeed;
    }

    void FixedUpdate()
    {
        GetSpeedFromInputs();

        CallSpeedChangeEvent();
    }

    private void Update()
    {
        if (HasSpeed())
        {
            MoveUsingSpeed();
        }
    }

    private void GetSpeedFromInputs()
    {
        CurrentHorizontalSpeed = Input.GetAxis("Horizontal") * MaxHorizontalSpeed;
        CurrentVerticalSpeed = Input.GetAxis("Vertical") * MaxVerticalSpeed;
    }

    private void CallSpeedChangeEvent()
    {
        SpeedChange.Invoke();
    }

    public bool HasSpeed()
    {
        return (CurrentHorizontalSpeed != 0f || CurrentVerticalSpeed != 0f);
    }
    

}
