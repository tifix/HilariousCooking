using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public List<string> tags = new List<string>();
    public bool isAdded = false;
    public Transform originalParent;

    // Update is called once per frame
    void Start()
    {
        originalParent = transform.parent;
    }

}
