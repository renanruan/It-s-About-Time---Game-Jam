using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeRanges
{
    private AgeRange[] Ranges;

    private int CurrentRangeID = -1;

    private struct AgeRange
    {
        public int MinValue;

        public int MaxValue;
    }

    public AgeRanges (int minValue, int maxValue, int ranges, int startingAge)
    {
        int rangeSize = (maxValue - minValue) / ranges;

        Ranges = new AgeRange[ranges];

        for(int i = 0; i < ranges; i++)
        {
            AgeRange range = new AgeRange();

            range.MinValue = minValue + i * rangeSize;
            range.MaxValue = minValue + (1 + i) * rangeSize - 1;

            Ranges[i] = range;
        }

        CurrentRangeID = GetRangeIdFromAge(startingAge);
    }

    public bool DoesChangeStateForAge(int newAge)
    {
        int newRangeID = GetRangeIdFromAge(newAge);

        bool hasChanges = newRangeID != CurrentRangeID;

        CurrentRangeID = newRangeID;

        return hasChanges;
    }

    private int GetRangeIdFromAge(int currentAge)
    {
        for (int id = 0; id < Ranges.Length; id++)
        {
            AgeRange range = Ranges[id];

            if ((range.MinValue <= currentAge) && (range.MaxValue >= currentAge))
            {
                return id;
            }
        }

        return -1;
    }

    public UnitAge.AgeStage GetStage()
    {
        return (UnitAge.AgeStage)CurrentRangeID;
    }
}


