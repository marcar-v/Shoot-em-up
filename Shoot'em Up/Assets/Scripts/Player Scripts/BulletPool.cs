using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] int bulletPoolSize = 10;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject[] bullets;
    [SerializeField] int shootNumber = -1;
    [SerializeField] GameObject bulletPosition1;


    private void Start()
    {
        bullets = new GameObject[bulletPoolSize];
        for (int i = 0; i < bulletPoolSize; i++)
        {
            bullets[i] = Instantiate(bullet, new Vector2(-10f, 0), Quaternion.identity);
            bullets[i].transform.parent = transform;
        }
    }
    public void ShootBullet()
    {
        shootNumber++;
        if (shootNumber > 9)
        {
            shootNumber = 0;
        }
        bullets[shootNumber].transform.position = bulletPosition1.transform.position;
        bullets[shootNumber].SetActive(true);
    }
}
