using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DraggableData;


[CreateAssetMenu(fileName = "Customer", menuName = "ScriptableObjects/Customer")]
public class SO_Customer : ScriptableObject
{
    public string Name;
    public List<keywords> desired;
    public Sprite image;
    public List<string> dialogue= new List<string>();
    List<string> desiredInString = new List<string>();

    public Dictionary<keywords, string> Outcomes = new Dictionary<keywords, string>();  //first is the required combo/tag/element, the second is the resulting dialogue

    private void Awake()
    {
        foreach(keywords k in desired)
        {
            desiredInString.Add(k.ToString());
        }
    }

    public void Evaluate(List<string> ingredients, List<string> keywords) 
    {
        int score = 0;

        foreach (string k in keywords)
        {
            if (desiredInString.Contains(k)) { score++; }     
        }

        Debug.Log("Score = " +score);


        UI_Controller.instance.PlayAnim("NewCustomer");
        //if funky combo detected, make that the text
        //UI_Controller.instance.DialogueDisplayer.text = Outcomes[desired[k]];
    }


}
