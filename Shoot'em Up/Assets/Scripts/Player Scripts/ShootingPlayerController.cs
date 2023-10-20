using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet1 = (GameObject)Instantiate(playerBullet);
            bullet1.transform.position = bulletPosition1.transform.position;
        }
    }
}
