using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;
    [SerializeField] AudioSource shootSound;


    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            shootSound.Play();

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullets>().SetDirection(direction);
        }
    }

}
