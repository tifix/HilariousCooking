using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "IngredientObject", menuName = "ScriptableObjects/Ingredient")]
public class SO_Ingredient : ScriptableObject
{
    public string Name;
    public category shelf;
    public Image image;



    public enum category
    {
        Tool
    }


}
