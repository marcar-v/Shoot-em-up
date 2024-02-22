using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDamaged : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionAnim;
    [SerializeField] Animator animator;

    AudioController _audioController = AudioController.audioControllerInstance;

    [Header("Lives")]
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] int maxLives = 3;
    private int currentLives;
    bool isDead;

    [SerializeField] GameObject gameOverCanvas;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        currentLives = maxLives;
        lifeText.text = currentLives.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            PlayerisDamaged();
            PlayerDead();
        }
    }

    public void PlayerisDamaged()
    {
        animator.Play("Hit");

        currentLives--;
        lifeText.text = currentLives.ToString();

    }

    public void PlayerDead()
    {
        if (currentLives == 0)
        {
            isDead = true;

            Invoke("GameOver", 1f);

            PlayExplosion();

            gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        if(isDead)
        {
            Time.timeScale = 0f;
            gameOverCanvas.SetActive(true);
        }
    }

    void PlayExplosion()
    {
        Instantiate(playerExplosionAnim, transform.position, Quaternion.identity);

        _audioController.PlayShipExplosion();
    }
}
