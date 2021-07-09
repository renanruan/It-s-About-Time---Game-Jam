using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeWithStage : MonoBehaviour
{
    [SerializeField]
    private UnitAge MyAge;

    [SerializeField]
    private GameObject[] MyObjects;

    [SerializeField]
    private Vector2[] MySizes;

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
        foreach(GameObject go in MyObjects)
        {
            go.transform.localScale = MySizes[(int)newStage];
        }
    }
}
