using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunBarrel : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public GameObject PlayerUnit;

    public PlayerAimCursor AimCursor;

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



}
