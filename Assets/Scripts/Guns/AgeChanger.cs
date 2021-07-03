using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeChanger
{
    private float AgeValue;

    private CollisionChecker MyCollider;

    private GameObject Source;
    private GameObject Detected;

    public AgeChanger(float AgeValue, CollisionChecker MyCollider, GameObject sourceGameObject)
    {
        this.AgeValue = AgeValue;
        this.MyCollider = MyCollider;
        this.Source = sourceGameObject;

        RegisterCollisionEvent();
    }

    private void RegisterCollisionEvent()
    {
        MyCollider.RegisterCollisionDetection(OnCollision);
    }

    private void OnCollision()
    {
        GetDetected();

        if (IsDetectedAgeable())
        {
            DeageSource();
            AgeDetected();
        }
    }

    private void GetDetected()
    {
        Detected = MyCollider.GetDetected();
    }

    private bool IsDetectedAgeable()
    {
        return Detected.tag.Contains("Ageable");
    }

    private void DeageSource()
    {
        Source.GetComponent<Ageable>().ChangeAge(-AgeValue);
    }
    private void AgeDetected()
    {
        Detected.GetComponent<Ageable>().ChangeAge(AgeValue);
    }
}
