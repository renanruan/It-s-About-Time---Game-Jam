using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : UnitMovement, Pushable
{
    [SerializeField]
    private float MaxVerticalSpeed = 1;
    [SerializeField]
    private float MaxHorizontalSpeed = 1;

    [SerializeField]
    private float FrictionFactor = 1;

    public void Push(Vector3 Direction)
    {
        print("Push");
        SetSpeed(Direction);
        StartPushMoviment();
    }

    private void SetSpeed(Vector3 Direction)
    {
        CurrentHorizontalSpeed = Direction.x * MaxHorizontalSpeed;
        CurrentVerticalSpeed = Direction.y * MaxVerticalSpeed;
    }

    private void StartPushMoviment()
    {
        enabled = true;
    }

    public Vector3 GetSpeed()
    {
        return new Vector3(CurrentHorizontalSpeed, CurrentVerticalSpeed);
    }

   
    void FixedUpdate()
    {
        MoveUsingSpeed();
        ApplyFriction();
        CheckEndOfPush();
    }

    private void ApplyFriction()
    {
        CurrentHorizontalSpeed = ApplyFrictionOnAxe(CurrentHorizontalSpeed);
        CurrentVerticalSpeed = ApplyFrictionOnAxe(CurrentVerticalSpeed);
    }

    private float ApplyFrictionOnAxe(float CurrentAxeSpeed)
    {
        float newValue = 0;

        if(CurrentAxeSpeed > 0)
        {
            newValue = CurrentAxeSpeed - FrictionFactor * Time.deltaTime;

            if(newValue < 0.1f)
            {
                newValue = 0;
            }
        }
        else if( CurrentAxeSpeed < 0)
        {
            newValue = CurrentAxeSpeed + FrictionFactor * Time.deltaTime;

            if (newValue > -0.1f)
            {
                newValue = 0;
            }
        }

        return newValue;
    }

    private void CheckEndOfPush()
    {
        if(IsThereNoSpeed())
        {
            EndOfPush();
        }
    }

    private bool IsThereNoSpeed()
    {
        return CurrentHorizontalSpeed == 0 && CurrentVerticalSpeed == 0;
    }

    private void EndOfPush()
    {
        enabled = false;
    }
}
