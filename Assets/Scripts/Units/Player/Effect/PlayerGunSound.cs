using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] ShotSound;

    private static int CurrentID = 0;

    [SerializeField]
    private int VariationSound;

    public void PlaySound()
    {
        ShotSound[CurrentID].Play();
        ChangeIdBy(VariationSound);
    }

    private void ChangeIdBy(int i)
    {
        CurrentID = (CurrentID + ShotSound.Length + i) % ShotSound.Length;
    }
}
