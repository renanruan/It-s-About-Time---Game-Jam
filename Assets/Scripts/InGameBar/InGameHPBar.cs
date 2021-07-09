using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHPBar : MonoBehaviour
{
    [SerializeField]
    private Transform MaskSprite;

    [SerializeField]
    private BarTransparency barTransparency;

    public void SetHealthBarTo(float percentage)
    {
        MaskSprite.localScale = new Vector3(percentage, 1, 0);
        barTransparency.ShowBar();
    }
}
