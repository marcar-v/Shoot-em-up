using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] GameObject bulletPosition2;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet1 = (GameObject)Instantiate(playerBullet);
            bullet1.transform.position = bulletPosition1.transform.position;
            GameObject bullet2 = (GameObject)Instantiate(playerBullet);
            bullet2.transform.position = bulletPosition2.transform.position;
        }
    }
}
