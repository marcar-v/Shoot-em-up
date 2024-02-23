using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    Vector3 _direction = Vector3.right;
    float downEdge = -8f;

    [Header("Enemy Damaged Settings")]
    [SerializeField] GameObject enemyExplosionAnimation;
    protected GameObject scoreText;
    AudioController audioController = AudioController.audioControllerInstance;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
    }

    #region "Movement"
    private void Update()
    {
        Movement();
        DestroyShip();
    }

    void Movement()
    {
        this.transform.position += _direction * Time.deltaTime * this.speed;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform enemy in transform)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && enemy.position.x >= (rightEdge.x - 2f))
            {
                ChangeDirection();
            }
            else if (_direction == Vector3.left && enemy.position.x <= (leftEdge.x + 2f))
            {
                ChangeDirection();
            }
        }
    }
    void DestroyShip()
    {
        if (transform.position.y < downEdge)
        {
            Destroy(gameObject);
        }
    }
    void ChangeDirection()
    {
        _direction.x *= -1f;
        Vector3 position = transform.position;
        position.y -= 0.5f;
        transform.position = position;
        speed += 0.1f;
    }
    #endregion

    #region "Damaged"


    public virtual void PlayExplosion()
    {
        Instantiate(enemyExplosionAnimation, transform.position, Quaternion.identity);

        //audioController.PlayShipExplosion();
    }
    #endregion
}