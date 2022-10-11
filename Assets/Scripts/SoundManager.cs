using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip playerJump,PlayerWalk, coinCollect, winSound,playerShoot;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //If we need to sound effects
   
    public void PlayPlayerJump()
    {
        audioSource.PlayOneShot(playerJump);
    }

    public void PlayCoinCollect()
    {
        audioSource.PlayOneShot(coinCollect);
    }

    public void PlayWindSound()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void PlayPlayerShoot()
    {
        audioSource.PlayOneShot(playerShoot);
    }

    public void PlayPlayerWalk()
    {
        audioSource.PlayOneShot(PlayerWalk);
    }

}
