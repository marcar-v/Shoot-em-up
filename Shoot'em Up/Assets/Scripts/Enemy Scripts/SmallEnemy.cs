using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : EnemyController
{
    [SerializeField] int lives = 1;

    private void OnEnable()
    {
        specialAttack.specialAttackReleased += EnemyDead;
    }

    private void OnDisable()
    {
        specialAttack.specialAttackReleased -= EnemyDead;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerBullet")
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        lives--;
        if (lives == 0)
        {
            scoreText.GetComponent<GameScore>().Score += 100;

            PlayExplosion();

            Destroy(gameObject);
        }
    }
}
