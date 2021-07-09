using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeableObjectMovement : UnitMovement, Pushable
{
    [SerializeField]
    private float MaxVerticalSpeed = 1;
    [SerializeField]
    private float MaxHorizontalSpeed = 1;

    [SerializeField]
    private float FrictionFactor = 1;

    [SerializeField]
    private BoxCollider2D MyCollider;

    [SerializeField]
    private UnitAge MyAge;

    private int stageFactor;


    void Start()
    {
        StartUnitMoviment();
        MyAge.RegisterAgeStageEvent(OnAgeChange);
    }

    private void OnAgeChange(UnitAge.AgeStage newStage)
    {
        stageFactor = ((int)newStage * 3) + 1;
    }

    public void Push(Vector3 Direction)
    {
        SetSpeed(Direction);
        if (IsPathClear())
        {
            StartPushMoviment();
        }
        else
        {
            SetSpeed(Vector3.zero);
        }

    }

    private void SetSpeed(Vector3 Direction)
    {
        CurrentHorizontalSpeed = Direction.x * MaxHorizontalSpeed / stageFactor;
        CurrentVerticalSpeed = Direction.y * MaxVerticalSpeed / stageFactor;
    }

    private bool IsPathClear()
    {
        Vector3 Direction = GetSpeed();
        return Physics2D.BoxCast(MyCollider.transform.position, MyCollider.size, 0, Direction, Direction.magnitude * Time.deltaTime, LayerMask.GetMask("Wall")).collider == null;
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

        if (CurrentAxeSpeed > 0)
        {
            newValue = CurrentAxeSpeed - FrictionFactor * Time.deltaTime;

            if (newValue < 0.1f)
            {
                newValue = 0;
            }
        }
        else if (CurrentAxeSpeed < 0)
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
        if (IsThereNoSpeed())
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
