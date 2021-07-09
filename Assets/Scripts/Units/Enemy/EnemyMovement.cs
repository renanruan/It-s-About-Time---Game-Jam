using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private EnemyEyeSeeker EyeSeeker;

    [SerializeField]
    private Animator EnemyAnimator;

    [SerializeField]
    private BoxCollider2D EnemyCollider;

    [SerializeField]
    private GameObject EnemyUnit;

    private bool GettingClose = false;

    private bool Moving = false;

    private bool ClockWise = false;

    [Header("Settings")]
    [SerializeField]
    private float MaxSpeed = 1;

    private float Speed;

    [SerializeField]
    private float MaxTimeBetweenChanges = 1;

    private float TimeBetweenChanges = 0;



    private Transform PlayerPosition;

    private Vector3 Direction;


    private void Start()
    {
        EyeSeeker.RegisterSeekEvent(DetectedPlayer);
    }


    private void DetectedPlayer(Transform playerBody)
    {
        if(playerBody != null)
        {
            PlayerPosition = playerBody;

            if (!Moving)
            {
                Moving = true;
                ChangeHappens();
            }
            
        }
        else
        {
            if (Moving)
            {
                EnemyAnimator.SetBool("Moving", false);
                Moving = false;
            }
        }
    }



    private void Update()
    {
        if (!Moving)
        {
            return;
        }

        TimeBetweenChangesPasses();

        if (IsTimeToChange())
        {
            ChangeHappens();
        }

        MoveAround();
    }

    private void TimeBetweenChangesPasses()
    {
        TimeBetweenChanges -= Time.deltaTime;
    }

    private bool IsTimeToChange()
    {
        return TimeBetweenChanges < 0;
    }

    private void ChangeHappens()
    {
        GettingClose = FlipCoin(50, 50);

        ClockWise = FlipCoin(50, 50);

        GetClosingSpeed();

        GetTimeBetweenChanges();
    }

    private bool FlipCoin(int PercentageYes, int PercentageNo)
    {
        int result = Random.Range(0, PercentageYes + PercentageNo);

        return result < PercentageYes;
    }

    private void GetClosingSpeed()
    {
        Speed = Random.Range(MaxSpeed * 0.75f, MaxSpeed);
    }


    private void GetTimeBetweenChanges()
    {
        TimeBetweenChanges = Random.Range(MaxTimeBetweenChanges * 0.25f, MaxTimeBetweenChanges);
    }


    private void MoveAround()
    {
        CalculateDirection();

        if (IsPathClear())
        {
            MoveFollowingDirection();
            EnemyAnimator.SetBool("Moving", true);
        }
        else
        {
            ChangeHappens();
            EnemyAnimator.SetBool("Moving", false);
        }
    }

    private void CalculateDirection()
    {
        Vector3 newDirection = (PlayerPosition.position - transform.position);

        int signal = (ClockWise) ? 1 : -1;

        int closing = (GettingClose) ? 10 : -10;


        Direction = (Quaternion.AngleAxis(signal * (90 + closing), Vector3.forward) * newDirection).normalized;

    }

    private bool IsPathClear()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, EnemyCollider.size , 0 ,Direction, Speed * Time.deltaTime, LayerMask.GetMask("Object","Wall"));

        return hit.collider == null;
    }

    private void MoveFollowingDirection()
    {
        EnemyUnit.transform.position += Direction * Speed * Time.deltaTime;
    }

}
