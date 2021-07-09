using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ageable
{
    void ChangeAgeBy(float deltaChange);

    bool CanAgeAmount(float deltaAmount);
}
