using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunBarrel : MonoBehaviour
{
    [SerializeField]
    private PlayerGunSound GunSounds;

    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private Transform BulletSpawnPoint;

    [SerializeField]
    private GameObject PlayerUnit;

    [SerializeField]
    private PlayerAimCursor AimCursor;

    [SerializeField]
    private Animator Glow;

    [SerializeField]
    private ParticleSystem Particles;

    private RecycleKeeper MyBarrel;

    private GameObject newBullet;

    private void Start()
    {
        CreateBarrel();
    }

    private void CreateBarrel()
    {
        MyBarrel = new RecycleKeeper(BulletPrefab);
    }

    public void Fire()
    {
        CreateBullet();
        SetBulletPosition();
        SetBulletRotation();
        SetBulletDirection();
        SetBulletOrigin();
        FireBullet();
        GlowOnShot();
        EmitParticles();
        PlaySound();
    }

    private void CreateBullet()
    {
        newBullet = MyBarrel.GetNewKeeped();
    }

    private void SetBulletPosition()
    {
        newBullet.transform.position = BulletSpawnPoint.position;
    }

    private void SetBulletRotation()
    {
        newBullet.transform.rotation = transform.rotation;
    }

    private void SetBulletDirection()
    {
        newBullet.GetComponent<Bullet>().SetShootingDirection(AimCursor.GetAimDirectionFromPlayer());
        
    }
    private void SetBulletOrigin()
    {
        newBullet.GetComponent<Bullet>().SetOrinalGameObject(PlayerUnit);
    }


    private void FireBullet()
    {
        newBullet.SetActive(true);
    }

    private void GlowOnShot()
    {
        Glow.SetTrigger("Glow");
    }

    private void EmitParticles()
    {
        Particles.Play();
    }

    private void PlaySound()
    {
        GunSounds.PlaySound();
    }

}
