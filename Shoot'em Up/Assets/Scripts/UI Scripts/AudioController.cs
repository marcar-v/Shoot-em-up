using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource pauseMenuIn;
    [SerializeField] AudioSource pauseMenuOut;

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
