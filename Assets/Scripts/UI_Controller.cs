using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    public Animator Anim;
    public Transform canvas;
    public Transform ScrollableParent; //Different gamescreens;
    public static UI_Controller instance;

    public int dialogueScreen = 0;
    public TextMeshProUGUI DialogueDisplayer;

    //on shelf reload, these are the objects loaded
    [SerializeField] GameObject[] NewOptions = new GameObject[0];
    //public 

    public void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlayAnim(string clip) { Debug.Log("Playing animation "+clip); Anim.SetTrigger(clip); }

    public void OnDrawerOpen(string category) 
    {
        PlayAnim("Drawer");

        //Remove the Prefabs already in the scene
        foreach (var D in ScrollableParent.transform.GetComponentsInChildren<DraggableData>()) 
        {
            Destroy(D.transform.parent);
        }

        //fill with RELEVANT prefabs
        NewOptions = Resources.LoadAll("Ingredient Objects") as GameObject[];
        foreach (var item in NewOptions)
        {
            //if(item.GetComponentInChildren< Draggable>().category !=category) {continue; }

            GameObject Ingredient = Instantiate(Resources.Load("Ingredient") as GameObject, ScrollableParent);
            if(Ingredient.TryGetComponent(out DraggableData D)) 
            {
            //TODO replace blank data with the relevant data here!
            }
        }
    }

    public void AdvanceDialogue() 
    {
        dialogueScreen++;
        //Add current customer reference to GameController
        //DialogueDisplayer.text = GameController.instance.curCustomer;
    }

}
