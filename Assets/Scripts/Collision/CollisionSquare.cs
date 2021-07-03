using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSquare : CollisionForm
{
    [SerializeField]
    private Vector2 DetectionSize;

    override public RaycastHit2D Detect(LayerMask DetectableLayers)
    {
        return Physics2D.BoxCast(transform.position, DetectionSize, transform.rotation.z, Vector3.zero, 0, DetectableLayers);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, DetectionSize);
    }
}
