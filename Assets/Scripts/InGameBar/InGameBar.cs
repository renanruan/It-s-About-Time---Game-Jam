using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBar : MonoBehaviour
{
    [Header("Components")]

    [SerializeField]
    private Transform Marker;

    [SerializeField]
    private BarTransparency Transparency;

    [Header("Bar Settings")]

    [SerializeField]
    private Transform MinMarkerPosition;

    [SerializeField]
    private Transform MaxMarkerPosition;


    private float MinBarValue;

    private float MaxBarValue;


    private float TotalRangValue;


    public void SetMinMaxValue(float MinValue, float MaxValue)
    {
        MinBarValue = MinValue;
        MaxBarValue = MaxValue;

        CalculateTotalRange();
    }

    private void CalculateTotalRange()
    {
        TotalRangValue = MaxBarValue - MinBarValue;
    }

    public void SetMarkerPosition(float NewBarValue)
    {
        SetPosition(CalculateNormalizedPosition(NewBarValue));
        ShowBarAndMarker();
    }

    private float CalculateNormalizedPosition(float NewBarValue)
    {
        return (NewBarValue - MinBarValue) / TotalRangValue;
    }

    private void SetPosition(float normalizedPosition)
    {
        Marker.position = Vector3.Lerp(MinMarkerPosition.position, MaxMarkerPosition.position, normalizedPosition);
    }

    private void ShowBarAndMarker()
    {
        Transparency.ShowBarAndMarker();
    }
}
