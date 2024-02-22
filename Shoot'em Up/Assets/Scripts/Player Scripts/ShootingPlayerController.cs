using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] AudioSource shootSound;

    [SerializeField] SpecialAttackController specialAttackController;

    private void Awake()
    {
        specialAttackController = FindObjectOfType<SpecialAttackController>();
    }

    private void OnEnable()
    {
        specialAttackController.specialAttackReleased += ShootSpecialAttack;
    }
    private void OnDisable()
    {
        specialAttackController.specialAttackReleased -= ShootSpecialAttack;
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && Time.timeScale > 0)
        {
            GameObject bullet1 = (GameObject)Instantiate(playerBullet);
            bullet1.transform.position = bulletPosition1.transform.position;

            shootSound.Play();
        }
    }

    public void ShootSpecialAttack()
    {
        Debug.Log("SpecialAttack");
    }

}
