using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DraggableData;

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
    public List<string> currentIngredients = new List<string>();
    public List<string> allCurrentKeywords = new List<string>();

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
            if (isOverPlate&&GO.TryGetComponent(out DraggableData D)) 
            {
                AddIngredient(D);
                Debug.Log("Snapping" + GO.name);
            }
            else if(GO.TryGetComponent(out DraggableData Dr))
            {
                RemoveIngredient(Dr);
                Debug.Log("Resetting" + GO.name);
            }
            curDragged = null;
        }
    }
    public void AddIngredient(DraggableData D) 
    {
        //Placing visually
        D.transform.SetParent(snapPlatePosition);
        D.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDragDistance));

        //Handling data
        //Adds name of ingredient to total list, and saves what place in the list it is.
        currentIngredients.Add(D.Properties.name);

        //Adds each keyword of this ingredient to the list of all keywords.
        foreach (keywords k in D.Properties.tags)
        {
            allCurrentKeywords.Add(k.ToString());
        }

        D.isAdded = true;
        AddCompleteCombos(D);

        showUpdatedLists();
    }

    //Sets an ingredient back to its starting point, then removes its name and keywords from the overall list.
    //It is important to note that keywords are removes when found, so while the data won't change, the order will (E.G. if I add two items with the kill keyword, then remove the second item, the first kill keyword will be removed, so the ammount will still be correct.
    public void RemoveIngredient(DraggableData D)
    {
        D.transform.SetParent(D.originalParent);
        D.transform.localPosition = Vector3.zero;

        if (D.isAdded)
        {
            D.isAdded = false;
            //for (int i = 0; i < D.Properties.Count; i++)
            //{
            //    currentIngredients.Remove(D.Properties[i]);
            //    RefreshCompleteCombos();
            //}
            currentIngredients.Remove(D.Properties.name);
            foreach (keywords keywords in D.Properties.tags)
            {
                allCurrentKeywords.Remove(keywords.ToString());
            }

            RemoveCombos(D);
        }

        showUpdatedLists();
    }

    //Takes in the added ingredient, goes through what it can combine with and compares them to whats currently on the pizza, then if it finds it, adds the keywords in that combination.
    void AddCompleteCombos(DraggableData D) 
    {
        foreach(combos c in D.Properties.Combos)
        {
            string cS = c.combosWith.ToString();
            if(currentIngredients.IndexOf(cS) > -1)
            {
                foreach(keywords k in c.createsTags)
                {
                    allCurrentKeywords.Add(k.ToString());
                }
            }
        }
    }

    //Takes in the ingredient being removes, sees if it is currently combined with anything, and removes those keywords from the total. 
    void RemoveCombos(DraggableData D)
    {
        foreach (combos c in D.Properties.Combos)
        {
            string cS = c.combosWith.ToString();
            if (currentIngredients.IndexOf(cS) > -1)
            {
                foreach (keywords k in c.createsTags)
                {
                    allCurrentKeywords.Remove(k.ToString());
                }
            }
        }
    }

    //Used for debugging data when needed.
    void showUpdatedLists()
    {
        Debug.Log("Ingredients = "+currentIngredients+ "At Length = " +currentIngredients.Count);
        Debug.Log("Keywords = " + allCurrentKeywords + "At Length = " + allCurrentKeywords.Count);
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
        foreach (DraggableData D in snapPlatePosition.GetComponentsInChildren<DraggableData>())
        {
            RemoveIngredient(D);
        }
    }
}
