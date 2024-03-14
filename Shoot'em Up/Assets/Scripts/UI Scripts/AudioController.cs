using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header ("UI SOUNDS")]
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource pauseMenuIn;
    [SerializeField] AudioSource pauseMenuOut;

    [SerializeField] AudioSource backgroundMusic;

    [Header("SHIP SOUNDS")]
    [SerializeField] AudioSource shipExplosionSound;

    public static AudioController audioControllerInstance = null;
    private void Awake()
    {
        if (audioControllerInstance == null)
        {
            audioControllerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (audioControllerInstance != this)
        {
            Debug.Log("Cuidado, más de un AudioController en escena.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    public void PlayShipExplosion()
    {
        shipExplosionSound.Play();
    }

    public void PlayButton()
    {
        clickSound.Play();
    }
    public void PlayMenuIn()
    {
        pauseMenuIn.Play();
    }

    public void PlayMenuOut()
    {
        pauseMenuOut.Play();
    }
}
