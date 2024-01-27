using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Animator Anim;
    public Transform canvas;
    public Transform ScreenOrder, ScreenKitchen, ScreenMenu; //Different gamescreens;
    public static UI_Controller instance;

    public void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlayAnim(string clip) { Debug.Log("Playing animation "+clip); Anim.SetTrigger(clip); }

}
