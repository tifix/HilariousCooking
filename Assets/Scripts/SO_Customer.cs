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
    public int[] gradeThresholds = { 0, 2, 4, 7 };

    public List<responsess> opinions;

    [System.Serializable]
    public struct responsess
    {
        public keywords desired;
        public List<string> dialogue;
        public responseAnim anim;
        public float scoreGain;

        public responsess(keywords k, responseAnim a) { desired = k; dialogue = new List<string>(); anim = a; scoreGain = 1f; }
    }

    public enum responseAnim
    {
        HappyCustomer,
        UnhappyCustomer,
        IndifferentCustomer
    }



}
