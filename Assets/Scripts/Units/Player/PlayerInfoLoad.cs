using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoLoad : MonoBehaviour
{
    [SerializeField]
    private UnitAge PlayerAge;

    [SerializeField]
    private PlayerHealth PlayerHP;

    private void Start()
    {
        float savedAge = PlayerInfoHolder.LoadPlayerAge();
        float savedHealth = PlayerInfoHolder.LoadPlayerHealth();

        if(savedAge > 0)
        {
            PlayerAge.SetAgeTo(savedAge);
        }

        if (savedHealth > 0)
        {
            PlayerHP.SetHealthTo(savedHealth);
        }

        enabled = false;
    }

    private void OnDestroy()
    {
        PlayerInfoHolder.SavePlayerAge(PlayerAge.GetAge());
        PlayerInfoHolder.SavePlayerHealth(PlayerHP.GetHealth());
    }
}
