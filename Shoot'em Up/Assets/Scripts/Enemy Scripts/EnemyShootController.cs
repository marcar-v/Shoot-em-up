using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPool;
    [SerializeField] AudioSource shootSound;
    [SerializeField] float fireRate;
    [SerializeField] float delay;

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
