using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Draggable;

public class customer
{
    public string name;
    public Sprite customerArt;
    public List<properties> desired;
}


public class GameController : MonoBehaviour
{
    [Range(0,2)] public float CHEAT_timescale = 1;
    public GameObject curDragged = null;

    public Transform snapPlatePosition;
    public float camDragDistance = 100;
    public bool isOverPlate;

    public static GameController instance;
    public List<properties> currentIngredients = new List<properties>();

    public void Awake()
    {
        if (instance == null) instance = this;
    }
    public void QuitGame() => Application.Quit();
    



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { UI_Controller.instance.PlayAnim("BackToMenu"); }
        ProcessDraggable();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (CHEAT_timescale != 1) Time.timeScale = CHEAT_timescale;
    }

    public void SetIsOverPlate(bool state)=>isOverPlate = state;


    //When in the kitchen screen, click and hold an ingredient to drag it
    public void BeginDrag(GameObject GO)  
    {
        Debug.Log("Dragging "+GO.name);
        curDragged = GO;
        curDragged.transform.SetParent(UI_Controller.instance.canvas);
    }

    //when holding and moving an ingredient, when letting go, if over the plate - add it to current ingredients, otherwise return it to its source position
    public void EndDrag(GameObject GO)
    {
        if(curDragged == GO) 
        {
            if (isOverPlate&&GO.TryGetComponent(out Draggable D)) 
            {
                AddIngredient(D);
                Debug.Log("Snapping" + GO.name);
            }
            else if(GO.TryGetComponent(out Draggable Dr))
            {
                RemoveIngredient(Dr);
                Debug.Log("Resetting" + GO.name);
            }
            curDragged = null;
        }
    }
    public void AddIngredient(Draggable D) 
    {
        D.transform.SetParent(snapPlatePosition);
        D.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDragDistance));

        currentIngredients.AddRange(D.Properties);
        D.isAdded = true;
        RefreshCompleteCombos();
    }
    public void RemoveIngredient(Draggable D)
    {
        D.transform.SetParent(D.originalParent);
        D.transform.localPosition = Vector3.zero;

        if (D.isAdded)
        {
            D.isAdded = false;
            for (int i = 0; i < D.Properties.Count; i++)
            {
                currentIngredients.Remove(D.Properties[i]);
                RefreshCompleteCombos();
            }
        }
    }

    void RefreshCompleteCombos() 
    {
        for (int i = 0; i < currentIngredients.Count; i++)
        {
            for (int j = 0; j < currentIngredients.Count; j++)
            {
                if (currentIngredients[i].combosWith == currentIngredients[j].name) currentIngredients[i].SetComboActive(true);
                else currentIngredients[i].SetComboActive(false);
            }
        }
    }


    //Update draggable position to current mouse position
    void ProcessDraggable() 
    {
        if (curDragged != null) { curDragged.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDragDistance)); }
    }

    //When pressing serve, bring the ingredients mix from the kitchen, check if the customer likes it and request next customer

    public void Serve() 
    {
    
    }

    public void Clear() 
    {
        foreach (Draggable D in snapPlatePosition.GetComponentsInChildren<Draggable>())
        {
            RemoveIngredient(D);
        }
    }
}
