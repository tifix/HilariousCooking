using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SO_Customer;
using static UnityEditor.Progress;

public class S_characterHandling : MonoBehaviour
{
    SO_Customer currentCustomer;
    List<string> desiredInString = new List<string>();
    List<string> response;
    List<int> ammount = new List<int>();
    public static S_characterHandling instance;


    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void startCharacter(SO_Customer customer)
    {

        currentCustomer = customer;
        desiredInString.Clear();
        ammount.Clear();

        foreach (responsess r in currentCustomer.opinions)
        {

            desiredInString.Add(r.desired.ToString());
            ammount.Add(0);
        }
    }



    public void Evaluate(List<string> ingredients, List<string> keywords)
    {
        UI_Controller.instance.DialogueDisplayer.text = "";
        float score = 0;
        int grade = -1;
        int whichOpinion = 0;

        List<string> found = new List<string>();

        foreach (string k in keywords)
        {
            //Finds where in the desiredinstring list (euqal length and order to opinions), then if it is there, does the following.
            int index = desiredInString.IndexOf(k);
            if (index > -1)
            {
                //Increase score, increases the integer in the ammount list (equal length and the order reflects the desiredinstring and opinions) to show which desired was found.
                score += currentCustomer.opinions[index].scoreGain;
                int p = ammount[index];
                ammount[index] = p + 1;

                //if (found.Contains(k))
                //{
                //    for (int i = 0; i < currentCustomer.opinions.Count; i++)
                //    {
                //        if (k == currentCustomer.opinions[i].desired.ToString())
                //            response = currentCustomer.opinions[i].dialogue;
                //    }
                //}
                found.Add(k);
            }
        }

        //Checks for what the highest in the int string that pararels the string list. Then sets the response at the equal index to be the set response.
        int highest = ammount.Max();
        if (highest > 0 && score >= currentCustomer.gradeThresholds[1])
        {
            int i = ammount.IndexOf(highest);
            whichOpinion = i;

            foreach (int g in currentCustomer.gradeThresholds)
                if (score >= g) { grade++; }
        }
        else
        {
            grade = 0;
            whichOpinion = 0;
        }


        try
        {
            Debug.Log("Score = " + score+ " Grade = " +grade);
            //Response related to most common keywords becomes the text and triggers its animation
            response = currentCustomer.opinions[whichOpinion].dialogue;
            UI_Controller.instance.DialogueDisplayer.text = response[0];
            UI_Controller.instance.PlayAnim(currentCustomer.opinions[whichOpinion].anim.ToString());

            foreach (string s in found)
            {
                Debug.Log("This contains" + s);
            }

        }
        catch { Debug.LogWarning("Combo detection broke! Triggering wait for next"); }

        //Adding the customer score to the total combined score
        GameController.instance.scoreTotal+= Mathf.RoundToInt(score * 10);

        //setting this means whenever a click anywhere is detected - it'll advance to the next customer
        GameController.instance.isCustomerFinished = true;

    }

}
