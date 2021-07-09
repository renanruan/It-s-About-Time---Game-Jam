using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float cyclePerSecond;

    public Vector2 range;

    private float angularSpeed;

    private Vector2 initialPosition;

    private float timer;

    private void Start()
    {
        angularSpeed = cyclePerSecond * 2 * Mathf.PI;
        initialPosition = transform.position;
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1/cyclePerSecond)
        {
            timer -= 1/cyclePerSecond;
        }

        transform.position = range * Mathf.Cos(angularSpeed * timer) + initialPosition;
    }

}
