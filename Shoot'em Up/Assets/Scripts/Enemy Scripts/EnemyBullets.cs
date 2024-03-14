using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    float speed = 5f;
    Vector2 bulletDirection;
    bool isReady;

    Transform enemy;

    private void Awake()
    {
        //speed = 5f;
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
        OnEnable();
    }

    private void OnEnable()
    {
        CanShoot();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -10f);
    }

    private void OnBecameInvisible()
    {
        gameObject.transform.position = enemy.transform.position;
        gameObject.SetActive(false);
    }

    void CanShoot()
    {
        if (isReady)
        {
            Vector2 position = transform.position;
            position += bulletDirection * speed * Time.deltaTime;
            transform.position = position;
            OnEnable();

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x)
              || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Edge")
        {
            gameObject.SetActive(false);
        }
    }
}
