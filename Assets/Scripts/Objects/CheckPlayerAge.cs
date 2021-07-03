using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerAge : CheckingForGate
{
    [Header("Blocking Settings")]
    [SerializeField]
    private UnitAge.AgeStage[] AllowedStages;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsPlayerAllowed(collision.transform))
            {
                SetOkTo(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetOkTo(false);
        }
    }

    private bool IsPlayerAllowed(Transform PlayerCollider)
    {
        UnitAge playerAge = PlayerCollider.parent.GetComponent<UnitAge>();

        UnitAge.AgeStage playerState = playerAge.GetStageAge();

        foreach (UnitAge.AgeStage stage in AllowedStages)
        {
            if (stage == playerState)
            {
                return true;
            }
        }
        return false;
    }
}
