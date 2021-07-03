using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TimeTick();
public class Timer
{
    private float TotalTime;

    private float CurrentTime;

    private event TimeTick Tick;

    public Timer(float TotalTime)
    {
        this.TotalTime = TotalTime;
    }


    public void RegisterTickEvent(TimeTick tickEvent)
    {
        Tick += tickEvent;
    }


    public void ResetTimer()
    {
        CurrentTime = TotalTime;
    }


    public void ConsumeTime()
    {
        Consume();

        if (IsTimeOver())
        {
            CallTickEvent();
        }
    }

    private void Consume()
    {
        CurrentTime -= Time.deltaTime;
    }

    private bool IsTimeOver()
    {
        return CurrentTime <= 0;
    }

    private void CallTickEvent()
    {
        Tick.Invoke();
    }

}
