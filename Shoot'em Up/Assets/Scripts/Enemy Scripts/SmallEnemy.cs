using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : EnemyController
{
    [SerializeField] int lives = 1;
    EnemySpawner instance;

    private void Start()
    {

    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerBullet")
        {
            EnemyDamaged();
            EnemyDead();

        }
    }

    void EnemyDamaged()
    {
        lives--;
    }

    void EnemyDead()
    {


        if (lives == 0)
        {
            scoreText.GetComponent<GameScore>().Score += 100;

            PlayExplosion();

            Destroy(gameObject);
        }
    }
}
