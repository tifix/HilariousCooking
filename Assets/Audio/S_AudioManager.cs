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
    public AudioClip[] BoomerTalk;
    public AudioClip[] pizzaTalk;
    public AudioClip[] babaTalk;

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
    public AudioSource sourceMain;
    public AudioSource sourceCharacter;
    public AudioSource sourceMusic;
    public AudioSource sourceSFX;

    public static S_AudioManager instance;
    private void Start()
    {
        if(sourceMain==null)             sourceMain = GetComponent<AudioSource>();
        if(sourceCharacter == null)     sourceMain = transform.GetChild(1).GetComponent<AudioSource>();
        if(sourceMusic == null)         sourceMain = transform.GetChild(2).GetComponent<AudioSource>();
        if(sourceSFX == null)         sourceMain = transform.GetChild(3).GetComponent<AudioSource>();
        //sourceMain = GetComponent<AudioSource>();
        StartMenuMusic();
        S_AudioManager.instance = this;
    }

    public void handleCharacterSounds()
    {
        
        string name = GameController.instance.Customers[GameController.instance.curCustomer].Name;
        switch (name)
        {
            case "BoomerLady":
                PlayBoomerSound();
                break;
            case "BabaYoga":
                PlayBabaSound();
                break;
            case "NSFWGuy":
                PlayNSFWSound();
                break;
            case "PizzaMan":
                PlayPizzaSound();
                break;
        }
    }

    public void PlayBoomerSound()
    {
        if (BoomerTalk.Length > 0)
        {
            int rand = Random.Range(0, BoomerTalk.Length);
            sourceCharacter.clip = BoomerTalk[rand];
            sourceCharacter.Play();
        }
    }

    public void PlayNSFWSound()
    {
        Debug.Log("playnsfw");
        if (NSFWTalk.Length > 0)
        {
            int rand = Random.Range(0, NSFWTalk.Length);
            sourceCharacter.clip = NSFWTalk[rand];
            sourceCharacter.Play();
        }
    }

    public void PlayBabaSound()
    {
        if (babaTalk.Length > 0)
        {
            int rand = Random.Range(0, babaTalk.Length);
            sourceCharacter.clip = babaTalk[rand];
            sourceCharacter.Play();
        }
    }

    public void PlayPizzaSound()
    {
        if (pizzaTalk.Length > 0)
        {
            int rand = Random.Range(0, pizzaTalk.Length);
            sourceCharacter.clip = pizzaTalk[rand];
            sourceCharacter.Play();
        }
    }

    public void PlayMenuClick()
    {
        if (click.Length > 0) {
        int rand = Random.Range(0, click.Length);
        sourceMain.clip = click[rand];
        sourceMain.Play();
        }
    }

    public void PlayMainStart()
    {
        if (startSound.Length > 0)
        {
            int rand = Random.Range(0, startSound.Length);
            sourceMain.clip = startSound[rand];
            sourceMain.Play();
        }
    }

    public void PlayMainExit()
    {
        if (quitSound.Length > 0)
        {
            int rand = Random.Range(0, quitSound.Length);
            sourceMain.clip = quitSound[rand];
            sourceMain.Play();
        }
    }

    public void StartMenuMusic()
    {
        if (menuMusic != null)
        {
            sourceMusic.clip = menuMusic;
            sourceMusic.Play();
        }
    }

    public void StartCookingMusic()
    {
        if (cookingMusic != null)
        {
            sourceMusic.clip = cookingMusic;
            sourceMusic.Play();
        }
    }

    public void playPlaceIngredient(AudioClip ingSound)
    {
        if (ingSound != null)
        {
            sourceSFX.clip = ingSound;
            sourceSFX.Play();
        }
    }

    public void playPickup()
    {
        if (pickUp.Length > 0)
        {
            int rand = Random.Range(0, pickUp.Length);
            sourceMain.clip = pickUp[rand];
            sourceMain.Play();
        }
    }


    public void playPutDown()
    {
        if (putDown.Length > 0)
        {
            int rand = Random.Range(0, putDown.Length);
            sourceMain.clip = putDown[rand];
            sourceMain.Play();
        }
    }

    public void playServe()
    {
        if (serve.Length > 0)
        {
            int rand = Random.Range(0, serve.Length);
            sourceSFX.clip = serve[rand];
            sourceSFX.Play();
        }
    }

    public void playTrash()
    {
        if (trash.Length > 0)
        {
            int rand = Random.Range(0, trash.Length);
            sourceSFX.clip = trash[rand];
            sourceSFX.Play();
        }
    }

    public void playDishSlide()
    {

    }
}
