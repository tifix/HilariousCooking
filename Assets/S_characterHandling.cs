using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Customer;
using static UnityEditor.Progress;

public class S_characterHandling : MonoBehaviour
{
    SO_Customer currentCustomer;
    List<string> desiredInString = new List<string>();
    List<string> response;

    public void startCharacter(SO_Customer customer)
    {
        currentCustomer = customer;
        desiredInString.Clear();

        foreach (responsess r in currentCustomer.opinions)
        {
            Debug.Log("desires  " + r.desired.ToString());
            desiredInString.Add(r.desired.ToString());
        }
    }



    public void Evaluate(List<string> ingredients, List<string> keywords)
    {
        Debug.Log("LENGTH OF KW = " + desiredInString.Count);

        int score = 0;
        response.Clear();

        List<string> found = new List<string>();

        foreach (string k in keywords)
        {
            if (desiredInString.Contains(k))
            {
                score++;

                if (found.Contains(k))
                {
                    for (int i = 0; i < currentCustomer.opinions.Count; i++)
                    {
                        if (k == currentCustomer.opinions[i].desired.ToString())
                            response = currentCustomer.opinions[i].dialogue;
                    }
                }
                found.Add(k);
            }

        }

        if (response.Count < 1)
        {
            if (score == 0)
                response = currentCustomer.opinions[0].dialogue;
            else
            {
                for (int i = 0; i < currentCustomer.opinions.Count; i++)
                {
                    if (found[0] == currentCustomer.opinions[i].desired.ToString())
                        response = currentCustomer.opinions[i].dialogue;
                }
            }

        }


        Debug.Log("Score = " + score);



        UI_Controller.instance.PlayAnim("NewCustomer");
        //if funky combo detected, make that the text
        //UI_Controller.instance.DialogueDisplayer.text = Outcomes[desired[k]];

        Debug.Log(response[0]);

    }

}
