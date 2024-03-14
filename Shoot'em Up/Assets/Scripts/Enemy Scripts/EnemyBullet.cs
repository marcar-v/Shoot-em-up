using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //[SerializeField] Transform enemySpawnPoint;
    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -10f);
    }
    private void OnBecameInvisible()
    {
        gameObject.transform.position = new Vector3(0f, 10f);
        gameObject.SetActive(false);
    }
}
