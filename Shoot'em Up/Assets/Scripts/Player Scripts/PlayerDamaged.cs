using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] GameObject gameManager;


    [SerializeField] GameObject playerExplosionAnimation;

    [Header("Lives")]
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] int maxLives = 3;
    private int currentLives;

    public void Init()
    {
        currentLives = maxLives;
        lifeText.text = currentLives.ToString();

        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            PlayExplosion();

            currentLives--;
            lifeText.text = currentLives.ToString();

            if (currentLives == 0)
            {
                gameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                gameObject.SetActive(false);
            }
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(playerExplosionAnimation);

        explosion.transform.position = transform.position;
    }
}
