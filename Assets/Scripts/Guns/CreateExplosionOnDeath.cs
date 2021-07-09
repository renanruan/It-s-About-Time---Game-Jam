using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosionOnDeath : MonoBehaviour
{
    [SerializeField]
    CollisionChecker MyCollider;

    [SerializeField]
    GameObject Explosion;

    private void Start()
    {
        RegisterCollisionEvent();
    }

    private void RegisterCollisionEvent()
    {
        MyCollider.RegisterCollisionDetection(OnCollision);
    }

    private void OnCollision()
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
    }
}
