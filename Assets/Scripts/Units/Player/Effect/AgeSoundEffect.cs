using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeSoundEffect : MonoBehaviour
{
    [SerializeField]
    private UnitAge MyAge;

    UnitAge.AgeStage currentStage = 0;

    [SerializeField]
    private AudioSource YoungSound;

    [SerializeField]
    private AudioSource OldSound;

    private void Start()
    {
        RegisterEvent();
    }

    private void RegisterEvent()
    {
        MyAge.RegisterAgeStageEvent(OnStageChange);
    }

    private void OnStageChange(UnitAge.AgeStage newStage)
    {
        if(newStage > currentStage)
        {
            PlayGetOldEffect();
        }
        else
        {
            PlayGetYoungEffect();
        }

        currentStage = newStage;
    }

    private void PlayGetYoungEffect()
    {
        OldSound.Stop();
        YoungSound.Play();
    }

    private void PlayGetOldEffect()
    {
        YoungSound.Stop();
        OldSound.Play();
    }
}
