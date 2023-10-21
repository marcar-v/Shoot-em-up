using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] AudioSource playerExplosionSound;
    [SerializeField] GameObject playerExplosionAnimation;
    [SerializeField] Animator animator;

    [Header("Lives")]
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] int maxLives = 3;
    private int currentLives;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        currentLives = maxLives;
        lifeText.text = currentLives.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {

            animator.Play("Hit");

            currentLives--;
            lifeText.text = currentLives.ToString();

            if (currentLives == 0)
            {
                PlayExplosion();

                playerExplosionSound.Play();

                gameObject.SetActive(false);
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(playerExplosionAnimation);

        explosion.transform.position = transform.position;
    }
}
