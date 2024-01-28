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
   
    public List<responsess> opinions;

    [System.Serializable]
    public struct responsess
    {
        public keywords desired;
        public List<string> dialogue;
    }


    //public Dictionary<keywords, string> Outcomes = new Dictionary<keywords, string>();  //first is the required combo/tag/element, the second is the resulting dialogue

 


}
