using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using UnityEditor;

public class UI_Controller : MonoBehaviour
{
    public Animator Anim;
    public Transform canvas;
    public Transform ScrollableParent; //Different gamescreens;
    public static UI_Controller instance;

    public int dialogueScreen = -1;
    public TextMeshProUGUI DialogueDisplayer;

    public S_AudioManager audioManager;

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
        foreach (var LE in ScrollableParent.transform.GetComponentsInChildren<LayoutElement>()) 
        {
            Destroy(LE.transform.gameObject);
        }

        //fill with RELEVANT prefabs
        //if (category == "Tools") NewOptions = Resources.LoadAll<GameObject>("Tools"); //AssetDatabase.LoadAllAssetsAtPath("Assets/Resources/Tools/");//Resources.LoadAll("Assets/Resources/Tools",typeof(GameObject)) as GameObject[];
        //if(category== "Foods") NewOptions = Resources.LoadAll<GameObject>("Foods");

        
        switch (category)
        {
            case ("Edible"): { NewOptions = Resources.LoadAll<GameObject>("Edible"); break; }
            case ("Non-edible"): { NewOptions = Resources.LoadAll<GameObject>("Non-edible"); break; }
            case ("???"): { NewOptions = Resources.LoadAll<GameObject>("Questionmark"); break; }

            default: { NewOptions = Resources.LoadAll("Edible") as GameObject[]; break; }
        }
    
        foreach (var item in NewOptions)
        {
            Instantiate(item, ScrollableParent);
        }
    }

    public void AdvanceDialogue() 
    {
        //Add current customer reference to GameController
        if(dialogueScreen< GameController.instance.curCustomer.dialogue.Count-1) dialogueScreen++;
        DialogueDisplayer.text = GameController.instance.curCustomer.dialogue[dialogueScreen];
    }

}
