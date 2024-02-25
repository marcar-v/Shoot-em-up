using UnityEngine;

public class ShootingPlayerController : MonoBehaviour
{

    public delegate void SpecialAttackDelegate();
    public event SpecialAttackDelegate specialAttackReleased;

    [SerializeField] GameObject playerBullet;
    [SerializeField] GameObject bulletPosition1;
    [SerializeField] AudioSource shootSound;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && Time.timeScale > 0)
        {
            GameObject bullet1 = (GameObject)Instantiate(playerBullet);
            bullet1.transform.position = bulletPosition1.transform.position;

            shootSound.Play();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpecialShoot();
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
}
