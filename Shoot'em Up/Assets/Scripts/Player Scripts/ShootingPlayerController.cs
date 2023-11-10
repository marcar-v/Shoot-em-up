using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingPlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] AudioSource shootSound;

    void Update()
    {
        var mouse = Mouse.current;

        if(mouse.leftButton.isPressed && Time.timeScale > 0)
        {
            GameObject bullet1 = (GameObject)Instantiate(playerBullet);
            bullet1.transform.position = bulletPosition1.transform.position;

            shootSound.Play();
        }
    }
}
