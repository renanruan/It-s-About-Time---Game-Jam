using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource ShotSound;

    public void PlaySound()
    {
        ShotSound.Play();
    }
}
