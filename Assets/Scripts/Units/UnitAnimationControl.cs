using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void AnimEvent();

public interface UnitAnimationControl
{
    public void TurnUnitInto(UnitAge.AgeStage stage);

    public void RegisterDieEvent(AnimEvent DieEvent);

    public void CallDieEvent();
}
