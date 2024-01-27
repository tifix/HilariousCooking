using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customer
{
    public string name;
    public Sprite customerArt;
    public List<string> desired;
}


public class GameController : MonoBehaviour
{
    [Range(0,2)] public float CHEAT_timescale = 1;
    public GameObject curDragged = null;
    //public Vector3 curDraggedOrigin = Vector3.zero;
    public float camDragDistance = 100;
    public Transform snapPlatePosition;
    //public Transform IngredientTransformParent;
    public float snapPlateRandomDistance = 10;
    public bool isOverPlate;

    public static GameController instance;
    public List<string> currentIngredients = new List<string>();

    public void Awake()
    {
        if (instance == null) instance = this;
    }
    public void QuitGame() 
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

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
                Debug.Log("Snapping" + GO.name);
                Vector3 randomOffset = new Vector3(Random.Range(snapPlateRandomDistance, -snapPlateRandomDistance), Random.Range(snapPlateRandomDistance, -snapPlateRandomDistance),0);

                curDragged.transform.SetParent(snapPlatePosition);
                curDragged.transform.localPosition = randomOffset;
                currentIngredients.AddRange(D.tags);
                D.isAdded = true;
            }
            else if(GO.TryGetComponent(out Draggable Dr))
            {
                Debug.Log("Resetting" + GO.name);
                curDragged.transform.SetParent(Dr.originalParent);
                curDragged.transform.localPosition =Vector3.zero;

                if (Dr.isAdded) 
                {
                    Dr.isAdded = false;
                    foreach (string t in Dr.tags)
                        currentIngredients.Remove(t);

                    

                }
                

            }

            curDragged = null;

        }
    }

    //Update draggable position to current mouse position
    void ProcessDraggable() 
    {
        if (curDragged != null) { curDragged.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDragDistance)); }
    }

    //When pressing serve, bring the ingredients mix from the kitchen, check if the customer likes it and request next customer
}
