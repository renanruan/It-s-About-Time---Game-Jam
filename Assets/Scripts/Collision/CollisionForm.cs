using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionForm : MonoBehaviour
{
    public abstract RaycastHit2D Detect(LayerMask DetectableLayers);
}
