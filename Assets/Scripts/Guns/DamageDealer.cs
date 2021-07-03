using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer
{
    private float DamageValue;

    private CollisionChecker MyCollider;

    private GameObject Detected;

    public DamageDealer(float DamageValue, CollisionChecker MyCollider)
    {
        this.DamageValue = DamageValue;
        this.MyCollider = MyCollider;

        RegisterCollisionEvent();
    }

    private void RegisterCollisionEvent()
    {
        MyCollider.RegisterCollisionDetection(OnCollision);
    }

    private void OnCollision()
    {
        GetDetected();

        if (IsDetectedDamegeable())
        {
            DamegeDetected();
        }
    }

    private void GetDetected()
    {
        Detected = MyCollider.GetDetected();
    }

    private bool IsDetectedDamegeable()
    {
        return Detected.tag.Contains("Enemy");
    }

    private void DamegeDetected()
    {

    }
}
