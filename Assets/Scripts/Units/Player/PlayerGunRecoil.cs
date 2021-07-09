using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunRecoil : MonoBehaviour
{
    [SerializeField]
    private UnitAge PlayerAge;

    [SerializeField]
    private float AgeChangeOnRecoil;

    public void RecoilGunFromYoungBullet()
    {
        ChangePlayerAge(+AgeChangeOnRecoil);
    }

    public void RecoilGunFromOldBullet()
    {
        ChangePlayerAge(-AgeChangeOnRecoil);
    }

    private void ChangePlayerAge(float amount)
    {
        PlayerAge.ChangeAgeBy(amount);
    }
}
