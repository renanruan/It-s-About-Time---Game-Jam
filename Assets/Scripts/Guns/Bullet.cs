using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Keeped
{
    [SerializeField]
    CollisionChecker MyCollider;

    [Header("Movement Settings")]

    [SerializeField]
    private float LifeSpawn;

    [SerializeField]
    private float MovementSpeed;

    private Timer DeathTimer;

    private  Vector3 MovementDirection;

    private GameObject OriginalGameObject;


    [Header("Actions")]

    [SerializeField]
    private float AgeToChangeOnHit;

    private AgeChanger MyAgeChanger;

    [SerializeField]
    private float DamageToDealOnHit;

    private DamageDealer MyDamageDealer;

    private void Awake()
    {
        CreateDeathTimer();
        CreateAgeChanger();
        CreateDamageDealer();
    }

    private void CreateDeathTimer()
    {
        DeathTimer = new Timer(LifeSpawn);
    }

    private void CreateAgeChanger()
    {
        if (AgeToChangeOnHit != 0)
        {
            MyAgeChanger = new AgeChanger(AgeToChangeOnHit, MyCollider, OriginalGameObject);
        }
    }

    private void CreateDamageDealer()
    {
        if (DamageToDealOnHit != 0)
        {
            MyDamageDealer = new DamageDealer(DamageToDealOnHit, MyCollider);
        }
    }


    private void Start()
    {
        RegisterTimerEvent();
        RegisterCollisionEvent();
    }

    private void RegisterTimerEvent()
    {
        DeathTimer.RegisterTickEvent(Die);
    }
    private void RegisterCollisionEvent()
    {
        MyCollider.RegisterCollisionDetection(OnCollision);
    }



    public void SetShootingDirection(Vector3 direction)
    {
        MovementDirection = direction;
    }

    public void SetOrinalGameObject(GameObject parentGameOBject)
    {
        OriginalGameObject = parentGameOBject;
    }





    private void OnEnable()
    {
        ResetDeathTimer();
    }

    private void ResetDeathTimer()
    {
        DeathTimer.ResetTimer();
    }





    void Update()
    {
        Move();

        ConsumeTimeTillDeath();
    }

    private void Move()
    {
        transform.position += Time.deltaTime * MovementDirection * MovementSpeed;
    }

    private void ConsumeTimeTillDeath()
    {
        DeathTimer.ConsumeTime();
    }



    private void OnCollision()
    {
        Die();
    }


    private void Die()
    {
        gameObject.SetActive(false);
        OriginalKeeper.ReturnKeepedToKeeper(gameObject);
    }
}
