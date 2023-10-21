using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{

    [SerializeField] GameObject enemyExplosionAnimation;
    [SerializeField] AudioSource enemyExplosionSound;

    GameObject scoreText;


    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerBullet")
        {
            PlayExplosion();

            scoreText.GetComponent<GameScore>().Score += 100;

            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(enemyExplosionAnimation);
        
        enemyExplosionSound.Play();

        explosion.transform.position = transform.position;
    }
}
