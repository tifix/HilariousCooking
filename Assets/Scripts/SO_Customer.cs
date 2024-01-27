using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
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
    List<string> response;
    public List<responsess> opinions;

    [System.Serializable]
    public struct responsess
    {
        public keywords desired;
        public List<string> dialogue;
    }


    //public Dictionary<keywords, string> Outcomes = new Dictionary<keywords, string>();  //first is the required combo/tag/element, the second is the resulting dialogue

    private void Awake()
    {

        foreach (responsess r in opinions)
        {
            Debug.Log("desires  " + r.desired.ToString());
            //desiredInString.Add(r.desired.ToString());
        }
    }

    public void Evaluate(List<string> ingredients, List<string> keywords) 
    {
        Debug.Log("LENGTH OF KW = " +desiredInString.Count);

        int score = 0;

        List<string> found = new List<string>();

        foreach (string k in keywords)
        {
            if (desiredInString.Contains(k)) 
            { 
                score++;    

                if (found.Contains(k))
                {
                    for (int i = 0; i < opinions.Count; i++)
                    {
                        if (k == opinions[i].desired.ToString())
                            response = opinions[i].dialogue;
                    }
                }
                found.Add(k);
            }
                
        }

        if(response.Count < 1)
        {
            if(score == 0)
                response = opinions[0].dialogue;
            else
            {
                for (int i = 0; i < opinions.Count; i++)
                {
                    if (found[0] == opinions[i].desired.ToString())
                        response = opinions[i].dialogue;
                }
            }

        }


        Debug.Log("Score = " +score);



        UI_Controller.instance.PlayAnim("NewCustomer");
        //if funky combo detected, make that the text
        //UI_Controller.instance.DialogueDisplayer.text = Outcomes[desired[k]];

        Debug.Log(response[0]);

    }


}
