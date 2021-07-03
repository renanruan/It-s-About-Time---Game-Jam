using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UnitMovement
{
    [SerializeField]
    private float MaxVerticalSpeed = 1;
    [SerializeField]
    private float MaxHorizontalSpeed = 1;

    public event AnimEvent SpeedChange;

    void FixedUpdate()
    {
        GetSpeedFromInputs();

        CallSpeedChangeEvent();

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
