using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] int bulletPoolSize = 10;
    [SerializeField] GameObject bullet;
    [SerializeField] List<GameObject> bulletsPool;
    [SerializeField] int shootNumber = 0;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] GameObject bulletPosition2;


    private void Start()
    {
        bulletsPool = new List<GameObject>(5);
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullets = Instantiate(bullet, new Vector2(-10f, 0), Quaternion.identity);
            bulletsPool.Add(bullets);
            bullets.transform.parent = transform;
        }
    }
    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber > 9)
        {
            shootNumber = 0;
        }
        bulletsPool[shootNumber].transform.position = bulletPosition1.transform.position;
        bulletsPool[shootNumber].SetActive(true);
    }
}
