using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDetection();

public class CollisionChecker : MonoBehaviour
{
    [SerializeField]
    private LayerMask DetectableLayers;

    [SerializeField]
    private CollisionForm Detector;

    private RaycastHit2D Detected;

    private event OnDetection OnCollisionDetection;


    public void RegisterCollisionDetection(OnDetection eventListener)
    {
        OnCollisionDetection += eventListener;
    }

    void Update()
    {
        CheckCollision();

        if (HasCollided())
        {
            CallCollisionEvent();
        }
    }

    private void CheckCollision()
    {
        Detected = Detector.Detect(DetectableLayers);
    }

    private bool HasCollided()
    {
        return Detected.collider != null;
    }

    private void CallCollisionEvent()
    {
        OnCollisionDetection.Invoke();
    }

    public void TurnColliderOff()
    {
        enabled = false;
    }

    public GameObject GetDetected()
    {
        return Detected.collider.transform.parent.gameObject;
    }


}
