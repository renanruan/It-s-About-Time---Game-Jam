using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeped : MonoBehaviour
{
    protected RecycleKeeper OriginalKeeper;

    public void SetOriginalKeeper(RecycleKeeper originalKeeper)
    {
        OriginalKeeper = originalKeeper;
    }
}
