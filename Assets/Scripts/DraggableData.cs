using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Update is called once per frame
    void Start()
    {
        originalParent = transform.parent;
    }

    public void EndDrag() => GameController.instance.EndDrag(gameObject);
    public void BeginDrag() => GameController.instance.BeginDrag(gameObject);

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
        Map
    }

    public enum keywords
    {
        None,
        Death,
        Fall,
        Dark,
        Slapstick,
        Nut,
        Horny,
        Weird
    }

}
