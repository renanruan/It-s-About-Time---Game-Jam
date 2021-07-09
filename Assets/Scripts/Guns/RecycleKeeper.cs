using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleKeeper
{
    private List<GameObject> Keepeds;

    private GameObject KeepedPrefab;

    private GameObject Keeper;


    public RecycleKeeper (GameObject keepedPrefab)
    {
        Keepeds = new List<GameObject>();
        KeepedPrefab = keepedPrefab;

        CreateKeeper();
    }

    private void CreateKeeper()
    {
        Keeper = new GameObject();
        Keeper.name = KeepedPrefab.name + " Holder" + Random.Range(0, 1000);
    }


    public GameObject GetNewKeeped()
    {
        if (IsThereKeepedsAvailable())
        {
            return GetKeepedFromKeeper();
        }
        else
        {
            return CreateNewKeeped();
        }
    }

    private bool IsThereKeepedsAvailable()
    {
        return Keepeds.Count > 0;
    }

    private GameObject GetKeepedFromKeeper()
    {
        GameObject recycledKeeped = Keepeds[0];

        Keepeds.RemoveAt(0);

        return recycledKeeped;
    }

    private GameObject CreateNewKeeped()
    {
        GameObject newKeeped = GameObject.Instantiate(KeepedPrefab, Keeper.transform);

        newKeeped.GetComponent<Keeped>().SetOriginalKeeper(this);

        return newKeeped;
    }

    public void ReturnKeepedToKeeper(GameObject oldKeeped)
    {
        Keepeds.Add(oldKeeped);
    }
}
