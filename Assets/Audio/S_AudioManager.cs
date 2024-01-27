using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class S_AudioManager : MonoBehaviour
{
    [Header("Main Menu Sounds")]
    public AudioClip startSound;
    public AudioClip quitSound;

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
    public AudioClip click;
    public AudioClip pickUp;
    public AudioClip putDown;

    [Header("CookingSounds")]
    public AudioClip trash;
    public AudioClip serve;

    [Header("Music")]
    public AudioClip menuMusic;
    public AudioClip cookingMusic;


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
        int rand = Random.Range(0, BoomerTalk.Length);
        characterSource.clip = BoomerTalk[rand];
        characterSource.Play();
    }

    public void PlayNSFWSound()
    {
        int rand = Random.Range(0, NSFWTalk.Length);
        characterSource.clip =  NSFWTalk[rand];
        characterSource.Play();
    }

    public void PlayMenuClick()
    {
        menuSource.clip = click;
        menuSource.Play();
    }

    public void PlayMainStart()
    {
        menuSource.clip = startSound;
        menuSource.Play();
    }

    public void PlayMainExit()
    {
        menuSource.clip = quitSound;
        menuSource.Play();
    }

    public void StartMenuMusic()
    {
        MusicSource.clip = menuMusic;
        MusicSource.Play();
    }

    public void StartCookingMusic()
    {
        MusicSource.clip = cookingMusic;
        MusicSource.Play();
    }

    public void playPlaceIngredient(AudioClip ingSound)
    {
        Source4.clip = ingSound;
        Source4.Play();
    }

    public void playPickup()
    {
        menuSource.clip = pickUp;
        menuSource.Play();
    }


    public void playPutDown()
    {
        menuSource.clip = putDown;
        menuSource.Play();
    }

    public void playServe()
    {
        Source4.clip = serve;
        Source4.Play();
    }

    public void playTrash()
    {
        Source4.clip = trash;
        Source4.Play();
    }
}
