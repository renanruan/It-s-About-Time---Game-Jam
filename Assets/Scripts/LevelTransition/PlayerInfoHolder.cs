using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoHolder : MonoBehaviour
{
    private static PlayerInfoHolder InfoHolder;

    private float PlayerAge;
    private float PlayerHealth;
    
    void Awake()
    {
        if(InfoHolder != null)
        {
            Destroy(gameObject);
        }
        else
        {
            InfoHolder = this;
            DontDestroyOnLoad(gameObject);
            enabled = false;
        }
    }

    public static void SavePlayerAge(float playerAge)
    {
        InfoHolder.PlayerAge = playerAge;
    }

    public static void SavePlayerHealth(float playerHealth)
    {
        InfoHolder.PlayerHealth = playerHealth;
    }

    public static float LoadPlayerAge()
    {
        return InfoHolder.PlayerAge;
    }

    public static float LoadPlayerHealth()
    {
        return InfoHolder.PlayerHealth;
    }




}
