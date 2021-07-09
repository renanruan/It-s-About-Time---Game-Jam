using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SeekerPosition(Transform playerBody);

public class EnemyEyeSeeker : MonoBehaviour
{
    [SerializeField]
    private float NormalEyeSight;

    [SerializeField]
    private float AlertEyeSight;

    private float CurrentEyeSight;

    [SerializeField]
    private LayerMask PlayerLayer;

    private Transform PlayerBody;

    private SeekerPosition SeekPlayerPosition;

    private void FixedUpdate()
    {
        LookForPlayerBody();

        if (HasFindPlayer())
        {
            SeekPlayer();
            CurrentEyeSight = AlertEyeSight;
        }
        else
        {
            SeekNothing();
            CurrentEyeSight = NormalEyeSight;
        }
    }

    private void LookForPlayerBody()
    {
        PlayerBody = Physics2D.CircleCast(transform.position, CurrentEyeSight, Vector2.zero, 0, PlayerLayer).transform;
    }

    private bool HasFindPlayer()
    {
        return PlayerBody != null;
    }

    private void SeekPlayer()
    {
        SeekPlayerPosition.Invoke(PlayerBody);
    }

    private void SeekNothing()
    {
        SeekPlayerPosition.Invoke(null);
    }

    public void RegisterSeekEvent(SeekerPosition seekFunction)
    {
        SeekPlayerPosition += seekFunction;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, NormalEyeSight);

        Gizmos.DrawWireSphere(transform.position, AlertEyeSight);
    }
}
