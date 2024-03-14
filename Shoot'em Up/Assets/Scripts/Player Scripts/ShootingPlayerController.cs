using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShootingPlayerController : MonoBehaviour
{

    public delegate void SpecialAttackDelegate();
    public event SpecialAttackDelegate specialAttackReleased;

    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] AudioSource shootSound;
    [SerializeField] GameObject specialAttackBullet;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && Time.timeScale > 0)
        {
            playerBullet.GetComponent<BulletPool>().ShootBullet();
            shootSound.Play();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Invoke("SpecialShoot", 0.5f);
            SpecialAttackBullet();
        }
    }

    void SpecialShoot()
    {
        if (specialAttackReleased != null)
        {
            Debug.Log("Bomb Released");
            specialAttackReleased();
        }
    }
    void SpecialAttackBullet()
    {
        GameObject specialBullet1 = (GameObject)Instantiate(specialAttackBullet);
        specialBullet1.transform.position = bulletPosition1.transform.position;
    }
}
