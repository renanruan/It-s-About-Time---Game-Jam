using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCircle : CollisionForm
{
    [SerializeField]
    private float DetectionRadius;

    override public RaycastHit2D Detect(LayerMask DetectableLayers)
    {
        return Physics2D.CircleCast(transform.position, DetectionRadius, Vector2.zero, 0, DetectableLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
