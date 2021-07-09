using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioControl : MonoBehaviour
{
    [SerializeField]
    private AudioSource HurtSound;

    [SerializeField]
    private AudioSource DeathSound;

    private void PlayHurtSound()
    {
        HurtSound.Stop();
        HurtSound.Play();
    }

    private void PlayDeathSound()
    {
        DeathSound.Play();
    }
}
