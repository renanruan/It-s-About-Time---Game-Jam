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
            if (CanAgeSource() && CanAgeDetected())
            {
                DeageSource();
                AgeDetected();
            }
            else
            {
                DoNotAgeSource();
                DoNotAgeDetected();
            }
            
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

    private bool CanAgeSource()
    {
        return Source.GetComponent<Ageable>().CanAgeAmount(-AgeValue);
    }

    private bool CanAgeDetected()
    {
        return Detected.GetComponent<Ageable>().CanAgeAmount(AgeValue);
    }

    private void DeageSource()
    {
        Source.GetComponent<Ageable>().ChangeAgeBy(-AgeValue);
    }
    private void AgeDetected()
    {
        Detected.GetComponent<Ageable>().ChangeAgeBy(AgeValue);
    }

    private void DoNotAgeSource()
    {
        Source.GetComponent<Ageable>().ChangeAgeBy(0);
    }

    private void DoNotAgeDetected()
    {
        Detected.GetComponent<Ageable>().ChangeAgeBy(0);
    }
}
