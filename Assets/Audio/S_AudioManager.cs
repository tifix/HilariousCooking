using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class S_AudioManager : MonoBehaviour
{
    [Header("Main Menu Sounds")]
    public AudioClip[] startSound;
    public AudioClip[] quitSound;

    [Header("Characters")]
    public AudioClip[] NSFWTalk;
    public AudioClip[] NSFWHappy;
    public AudioClip[] NSFWLaugh;
    public AudioClip[] NSFWUnhappy;
    public AudioClip[] BoomerTalk;
    public AudioClip[] BoomerHappy;
    public AudioClip[] BoomerLaugh;
    public AudioClip[] BoomerUnhappy;
    public AudioClip[] OtherTalk;

    [Header("Universal")]
    public AudioClip[] click;
    public AudioClip[] pickUp;
    public AudioClip[] putDown;

    [Header("CookingSounds")]
    public AudioClip[] trash;
    public AudioClip[] serve;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip cookingMusic;

    [Header("Audio Sources")]
    AudioSource menuSource;
    public AudioSource characterSource;
    public AudioSource MusicSource;
    public AudioSource Source4;
    private void Start()
    {
        menuSource = GetComponent<AudioSource>();
        StartMenuMusic();
    }


    public void PlayBoomerSound()
    {
        if (BoomerTalk.Length > 0)
        {
            int rand = Random.Range(0, BoomerTalk.Length);
            characterSource.clip = BoomerTalk[rand];
            characterSource.Play();
        }
    }

    public void PlayNSFWSound()
    {
        if (NSFWTalk.Length > 0)
        {
            int rand = Random.Range(0, NSFWTalk.Length);
            characterSource.clip = NSFWTalk[rand];
            characterSource.Play();
        }
    }

    public void PlayMenuClick()
    {
        if (click != null) {
        int rand = Random.Range(0, click.Length);
        menuSource.clip = click[rand];
        menuSource.Play();
        }
    }

    public void PlayMainStart()
    {
        if (startSound != null)
        {
            int rand = Random.Range(0, startSound.Length);
            menuSource.clip = startSound[rand];
            menuSource.Play();
        }
    }

    public void PlayMainExit()
    {
        if (quitSound != null)
        {
            int rand = Random.Range(0, quitSound.Length);
            menuSource.clip = quitSound[rand];
            menuSource.Play();
        }
    }

    public void StartMenuMusic()
    {
        if (menuMusic != null)
        {
            MusicSource.clip = menuMusic;
            MusicSource.Play();
        }
    }

    public void StartCookingMusic()
    {
        if (cookingMusic != null)
        {
            MusicSource.clip = cookingMusic;
            MusicSource.Play();
        }
    }

    public void playPlaceIngredient(AudioClip ingSound)
    {
        if (ingSound != null)
        {
            Source4.clip = ingSound;
            Source4.Play();
        }
    }

    public void playPickup()
    {
        if (pickUp != null)
        {
            int rand = Random.Range(0, pickUp.Length);
            menuSource.clip = pickUp[rand];
            menuSource.Play();
        }
    }


    public void playPutDown()
    {
        if (putDown != null)
        {
            int rand = Random.Range(0, putDown.Length);
            menuSource.clip = putDown[rand];
            menuSource.Play();
        }
    }

    public void playServe()
    {
        if (serve != null)
        {
            int rand = Random.Range(0, serve.Length);
            Source4.clip = serve[rand];
            Source4.Play();
        }
    }

    public void playTrash()
    {
        if (trash != null)
        {
            int rand = Random.Range(0, trash.Length);
            Source4.clip = trash[rand];
            Source4.Play();
        }
    }

    public void playDishSlide()
    {

    }
}
