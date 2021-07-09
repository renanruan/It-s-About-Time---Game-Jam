using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunBarrel : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private Transform BulletSpawnPoint;

    [SerializeField]
    private GameObject EnemyUnit;

    [SerializeField]
    private EnemyGunSound GunSounds;

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

    public void Fire(Vector2 PlayerPosition)
    {
        CreateBullet();
        SetBulletPosition();
        SetBulletRotation(PlayerPosition);
        SetBulletDirection(PlayerPosition);
        SetBulletOrigin();
        FireBullet();
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

    private void SetBulletRotation(Vector2 PlayerPosition)
    {
        Vector3 dir = PlayerPosition - (Vector2)BulletSpawnPoint.position;
        float bulletAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, bulletAngle);
    }

    private void SetBulletDirection(Vector2 PlayerPosition)
    {
        Vector2 Direction = (PlayerPosition - (Vector2)BulletSpawnPoint.position).normalized;
        newBullet.GetComponent<Bullet>().SetShootingDirection(Direction);

    }
    private void SetBulletOrigin()
    {
        newBullet.GetComponent<Bullet>().SetOrinalGameObject(EnemyUnit);
    }


    private void FireBullet()
    {
        newBullet.SetActive(true);
    }

    private void PlaySound()
    {
        GunSounds.PlaySound();
    }
}
