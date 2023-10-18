using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] GameObject gameManager;


    [SerializeField] GameObject playerExplosionAnimation;

    [Header("Lifes")]
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] int maxLifes = 3;
    private int currentLifes;

    public void Init()
    {
        currentLifes = maxLifes;
        lifeText.text = currentLifes.ToString();

        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            PlayExplosion();

            currentLifes--;
            lifeText.text = currentLifes.ToString();

            if (currentLifes == 0)
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
