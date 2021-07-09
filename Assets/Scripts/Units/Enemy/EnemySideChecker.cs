using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideChecker : MonoBehaviour
{
    [SerializeField]
    private Transform EnemySprite;

    [SerializeField]
    private EnemyEyeSeeker EyeSeeker;

    private void Start()
    {
        RegisterOnEyeSeeker();
    }

    private void RegisterOnEyeSeeker()
    {
        EyeSeeker.RegisterSeekEvent(LookToPlayertSide);
    }

    private void LookToPlayertSide(Transform PlayerPosition)
    {
        if (PlayerPosition == null)
            return;

        if(PlayerPosition.position.x > EnemySprite.position.x)
        {
            if(EnemySprite.localScale.x < 0)
            {
                InvertSides();
                return;
            }
        }
        else
        {
            if (EnemySprite.localScale.x > 0)
            {
                InvertSides();
                return;
            }
        }
    }

    private void InvertSides()
    {
        EnemySprite.localScale = new Vector3(-EnemySprite.localScale.x, EnemySprite.localScale.y, EnemySprite.localScale.z);
    }
}
