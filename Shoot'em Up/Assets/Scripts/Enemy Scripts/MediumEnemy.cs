using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : EnemyController
{
    [SerializeField] int lives = 2;
    [SerializeField] Animator animator;
    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "PlayerBullet")
        {
            EnemyDamaged();
            EnemyDead();
        }
    }

    private void OnEnable()
    {
        specialAttack.specialAttackReleased += EnemyDamaged;
    }

    private void OnDisable()
    {
        specialAttack.specialAttackReleased -= EnemyDamaged;
    }

    void EnemyDamaged()
    {
        animator.Play("EnemyDamaged");
        lives--;
    }

    void EnemyDead()
    {
        if (lives == 0)
        {
            scoreText.GetComponent<GameScore>().Score += 200;

            PlayExplosion();

            Destroy(gameObject);
        }
    }
}
