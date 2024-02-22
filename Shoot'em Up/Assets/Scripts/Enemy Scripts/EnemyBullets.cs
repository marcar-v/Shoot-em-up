using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullets : MonoBehaviour
{
    float speed = 5f;
    Vector2 bulletDirection;
    bool isReady;
    //float minDelay = 1f;
    //float maxDelay = 3f;

    //float upEdge = -1f;
    Transform enemy;

    private void Awake()
    {
        speed = 5f;
        isReady = false;
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    public void SetDirection(Vector2 direction)
    {
        direction = (Vector2.down * speed * Time.deltaTime);
        bulletDirection = direction.normalized;

        isReady = true;
    }

    private void Update()
    {
        CanShoot();
    }

    void CanShoot()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += bulletDirection * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x)
              ||(transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Edge")
        {
            Destroy(gameObject);
        }
    }
}
