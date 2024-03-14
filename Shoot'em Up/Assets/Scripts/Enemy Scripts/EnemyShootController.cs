using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    //[SerializeField] Transform enemySpawnPoint;
    [SerializeField] GameObject enemyBulletPool;
    //[SerializeField] AudioSource shootSound;
    [SerializeField] float nextShoot = 0f;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.T)))
        {
            enemyBulletPool.GetComponent<EnemyBulletPool>().ShootBullet();
            //shootSound.Play();
        }
    }

}
