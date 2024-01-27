using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableData : MonoBehaviour
{
    [System.Serializable]
    public struct properties
    {
        public string name;
        public List<combos> Combos;
        public List<keywords> tags;


        //public properties(string _t, string _c,bool _s) { name = _t;  combosWith = _c; isComboActive = _s; yesYouCan = new List<string>(); }
        //public properties(bool isCombo) { name = "";  combosWith = ""; isComboActive = isCombo; yesYouCan = new List<string>(); }

        //public void SetComboActive(bool state) {isComboActive= state;}
    }

    public struct combos
    {
        public  ingredientName combosWith;
        public List<keywords> createsTags;
    }

    public properties Properties;
    public bool isAdded = false;

    public Transform originalParent;


    // Update is called once per frame
    void Start()
    {
        originalParent = transform.parent;
    }

    public enum category
    {
        Tool
    }

    public enum ingredientName
    {
        Gun
    }

    public enum keywords
    {
        None
    }

}
