using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] int bulletPoolSize = 15;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] enemyBullets;
    [SerializeField] int shootNumber = -1;
    [SerializeField] GameObject enemyPosition;


    private void Start()
    {
        enemyBullets = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            enemyBullets[i] = Instantiate(bullet, new Vector2(-10f, 0), Quaternion.identity);
            enemyBullets[i].transform.parent = transform;
        }
    }
    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber > 14)
        {
            shootNumber = 0;
        }
        enemyBullets[shootNumber].transform.position = new Vector2 (0,0);
        enemyBullets[shootNumber].SetActive(true);
    }
    //public void ShootBullet()
    //{
    //    shootNumber++;
    //    if (shootNumber > 9)
    //    {
    //        shootNumber = 0;
    //    }
    //    //Transform enemyGunPosition = enemyBullets[shootNumber].transform.Find("EnemyGun");
    //    enemyBullets[shootNumber].transform.position = enemyPosition.transform.position;
    //    enemyBullets[shootNumber].SetActive(true);
    //}
}
