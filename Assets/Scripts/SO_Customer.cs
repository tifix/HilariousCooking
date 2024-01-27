using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DraggableData;

[CreateAssetMenu(fileName = "Customer", menuName = "ScriptableObjects/Customer")]
public class SO_Customer : ScriptableObject
{
    public string Name;
    public List<properties> desired;
    public Sprite image;
    public List<string> dialogue= new List<string>();

    public void Evaluate(List<string> ingredients, List<string> keywords) 
    {
    
    }
}
