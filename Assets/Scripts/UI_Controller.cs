using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Animator Anim;
    public Transform ScreenOrder, ScreenKitchen, ScreenMenu; //Different gamescreens;


    public void PlayAnim(string clip) { Anim.SetTrigger(clip); }

}
