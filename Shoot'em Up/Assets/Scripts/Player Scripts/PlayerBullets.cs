using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
    }
    private void OnBecameInvisible()
    {
        gameObject.transform.position = new Vector3(0, 0.3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Edge")
        {
            gameObject.SetActive(false);
        }
    }
}
