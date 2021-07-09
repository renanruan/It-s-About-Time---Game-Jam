using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBump : MonoBehaviour
{
    [SerializeField]
    private CollisionChecker MyCollider;

    [Header("Settings")]
    
    public float Force;

    public float Drag;

    public Vector3 Direction;

    public GameObject Target;


    void Update()
    {
        Bump();
        ApplyDrag();

        if (IsAlmostDone())
        {
            Stop();
        }
    }

    private void Bump()
    {
        Target.transform.position += Direction * Force * Time.deltaTime;
    }

    private void ApplyDrag()
    {
        Force -= Time.deltaTime * Drag;
    }

    private bool IsAlmostDone()
    {
        return Force < -0.1f;
    }

    private void Stop()
    {
        Destroy(gameObject);
    }
}
