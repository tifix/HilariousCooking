using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [System.Serializable]
    public struct properties
    {
        public string name;
        public string combosWith;
        public List<string> yesYouCan;
        public bool isComboActive;

        public properties(string _t, string _c,bool _s) { name = _t;  combosWith = _c; isComboActive = _s; yesYouCan = new List<string>(); }
        public properties(bool isCombo) { name = "";  combosWith = ""; isComboActive = isCombo; yesYouCan = new List<string>(); }

        public void SetComboActive(bool state) {isComboActive= state;}
    }

    public List<properties> Properties = new List<properties>();
    public bool isAdded = false;
    public Transform originalParent;


    // Update is called once per frame
    void Start()
    {
        originalParent = transform.parent;
    }

}
