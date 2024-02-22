using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] AudioSource shootSound;

    public float fireRate = 5;
    private float maxFireRate = 1;

    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f, fireRate);
    }


    void FireEnemyBullet()
    {
        if (fireRate > maxFireRate)
        {
        GameObject bullet = (GameObject)Instantiate(enemyBullet);

        shootSound.Play();

        bullet.transform.position = transform.position;

        Vector2 direction = transform.position - bullet.transform.position;

        bullet.GetComponent<EnemyBullets>().SetDirection(direction);

        fireRate = fireRate - 0.2f;
        }
    }

}
