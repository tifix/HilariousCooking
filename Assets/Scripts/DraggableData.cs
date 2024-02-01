using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DraggableData : MonoBehaviour
{
    [System.Serializable]
    public struct properties
    {
        public ingredientName name;
        public List<keywords> tags;


        //public properties(string _t, string _c,bool _s) { name = _t;  combosWith = _c; isComboActive = _s; yesYouCan = new List<string>(); }
        //public properties(bool isCombo) { name = "";  combosWith = ""; isComboActive = isCombo; yesYouCan = new List<string>(); }

        //public void SetComboActive(bool state) {isComboActive= state;}
    }

    [System.Serializable]
    public struct combos
    {
        public ingredientName combosWith;
        public List<keywords> createsTags;
    }

    public properties Properties;
    public List<combos> Combos;
    public AudioClip Sound;
    public bool isAdded = false;

    public Transform originalParent;

    public TextMeshProUGUI text;

    // Update is called once per frame
    void Start()
    {
        originalParent = transform.parent;
       
    }

    private void Awake()
    {
        text.text = Properties.name.ToString();
    }

    public void EndDrag() 
    {
        GetComponentInParent<Animator>().SetTrigger("endDrag");
        GameController.instance.EndDrag(gameObject);
    }


    public void BeginDrag()
    {
        GetComponentInParent<Animator>().SetTrigger("beginDrag");
        GameController.instance.BeginDrag(gameObject);
    } 

    public enum category
    {
        Tool,
        Food,
        Spice
    }

    public enum ingredientName
    {
        Gun,
        Banana,
        Coconut,
        Chicken,
        Peanut,
        Hazelnut,
        Existential,
        Computer,
        Coffee,
        Coke,
        Briefcase,
        Donut,
        Grinder,
        Knife,
        Lemon,
        Love,
        Muscle,
        Pizza,
        YOU,
        Cocaine,
        Scissors,
        Running,
        Baby,
        Dad,
        Explosion,
    
    }

    public enum keywords
    {
        Cool,
        Relatable,
        Sex,
        NSFW,
        Dangerous,
        Pizza,
        Nut,
        Slapstick,
        Dark,
        Meme,
        Commentary,
        Mean,
        Sweet,
        Relaxing,
        Business,
        Threatening,
        Dad,
        None,
        Healthy
    }

}
