using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class customer
{
    public string name;
    public Sprite customerArt;
    public List<string> desired;
}


public class GameController : MonoBehaviour
{
    [Range(0,2)] public float CHEAT_timescale = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { UI_Controller.instance.PlayAnim("BackToMenu"); }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (CHEAT_timescale != 1) Time.timeScale = CHEAT_timescale;
    }
}
