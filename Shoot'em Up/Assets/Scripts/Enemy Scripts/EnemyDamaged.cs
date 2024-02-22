using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{

    [SerializeField] GameObject enemyExplosionAnimation;
    GameObject scoreText;
    AudioController audioController = AudioController.audioControllerInstance;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerBullet")
        {
            scoreText.GetComponent<GameScore>().Score += 100;

            PlayExplosion();

            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        Instantiate(enemyExplosionAnimation, transform.position, Quaternion.identity);

        audioController.PlayShipExplosion();
    }
}
