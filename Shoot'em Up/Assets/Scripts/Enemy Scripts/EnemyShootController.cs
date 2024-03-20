using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPool;
    [SerializeField] AudioSource shootSound;
    private float fireRate = 2f;
    float delay = 3.5f;
    bool _canShoot = true;

    private void Start()
    {
        InvokeRepeating("Shoot", delay, fireRate);
    }

    void Shoot()
    {
        enemyBulletPool.GetComponent<BulletPool>().ShootBullet();
        shootSound.Play();
    }

}
