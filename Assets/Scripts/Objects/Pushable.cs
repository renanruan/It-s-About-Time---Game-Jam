using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pushable
{
    public void Push(Vector3 Direction);

    public Vector3 GetSpeed();
}
