using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;
using UnityEditor;
using UnityEngine.EventSystems;

public class UI_Controller : MonoBehaviour
{
    public Animator Anim;
    public Transform canvas;
    public Transform ScrollableParent; //Different gamescreens;
    public static UI_Controller instance;

    public int dialogueScreen = -1;
    public TextMeshProUGUI DialogueDisplayer;
    public TextMeshProUGUI WinScreenScore;
    public Image ClientSpriteDspplayer;
    public Image ClientTextBox;
    public Sprite TextboxNonInverted;

    public CanvasGroup AdvanceDialogueBox;

    public S_AudioManager audioManager;
    [SerializeField] private  EventSystem ES;

    //on shelf reload, these are the objects loaded
    [SerializeField] GameObject[] NewOptions = new GameObject[0];
    //public 

    void Awake()
    {
        if (instance == null) instance = this;
    }
    void Start()
    {
        OnDrawerOpen("Remove"); //Default open to edible drawer
        S_characterHandling.instance.startCharacter(GameController.instance.Customers[GameController.instance.curCustomer]);
    }


    public void PlayAnim(string clip) { Debug.Log("Playing animation "+clip); Anim.SetTrigger(clip); }


    public void OnDrawerOpen(string category) 
    {
        PlayAnim("Drawer");
        

        //Remove the Prefabs already in the scene
        foreach (var LE in ScrollableParent.transform.GetComponentsInChildren<LayoutElement>()) 
            Destroy(LE.transform.gameObject);


        switch (category)
        {
            case ("Edible"): { NewOptions = Resources.LoadAll<GameObject>("Edible"); break; }
            case ("Non-edible"): { NewOptions = Resources.LoadAll<GameObject>("Non-edible"); break; }
            case ("???"): { NewOptions = Resources.LoadAll<GameObject>("Questionmark"); break; }
            case ("Remove"):{ NewOptions = new GameObject[0]; break; }
            default: { NewOptions = Resources.LoadAll("Edible") as GameObject[]; break; }
        }
        if (NewOptions.Length < 1) return;

        foreach (var item in NewOptions)
        {
            Instantiate(item, ScrollableParent);
        }
    }

    public void AdvanceDialogue()
    {
        //Add current customer reference to GameController
        if (dialogueScreen < GameController.instance.Customers[GameController.instance.curCustomer].dialogue.Count - 1) 
        {
            dialogueScreen++;
            AdvanceDialogueBox.alpha=1;
        }
        else { AdvanceDialogueBox.alpha=0; }
        DialogueDisplayer.text = GameController.instance.Customers[GameController.instance.curCustomer].dialogue[dialogueScreen];
    }
    public void AdvanceToNextCustomer() 
    {
        if (GameController.instance.isCustomerFinished)
        {
            PlayAnim("NewCustomer");
            GameController.instance.isCustomerFinished = false;
        }

    }

    public void LoadCustomerData()
    {
        //when out of bounds, all customers done, win!
        GameController.instance.curCustomer++;
        if(GameController.instance.curCustomer>= GameController.instance.Customers.Length) { GameController.instance.Win(); return; }

        S_characterHandling.instance.startCharacter(GameController.instance.Customers[GameController.instance.curCustomer]);

        ClientTextBox.sprite = TextboxNonInverted;

        dialogueScreen = -1; //Reset the dialogue to the initial first screen;

        DialogueDisplayer.text = GameController.instance.Customers[GameController.instance.curCustomer].dialogue[0];
        ClientSpriteDspplayer.sprite = GameController.instance.Customers[GameController.instance.curCustomer].image;

        //Removing ingredients for the next guest
        GameController.instance.Clear();
    }
}
