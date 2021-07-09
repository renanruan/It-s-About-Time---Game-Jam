using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunAim : MonoBehaviour
{
    public PlayerAimCursor AimCursor;

    private float GunAngle;

    void Start()
    {
        RegisterAimMovementEvent();

        enabled = false;
    }

    private void RegisterAimMovementEvent()
    {
        AimCursor.MouseMoved += OnAimCursorMove;
    }

    private void OnAimCursorMove()
    {
        PointGunTowardsAim();
    }

    private void PointGunTowardsAim()
    {
        CalculateNewAngle();
        PointGunUsingAngle();
    }

    private void CalculateNewAngle()
    {
        Vector3 dir = AimCursor.GetAimDirectionFromPlayer();
        GunAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    private void PointGunUsingAngle()
    {
        transform.rotation = Quaternion.AngleAxis(GunAngle, Vector3.forward);
    }

}
