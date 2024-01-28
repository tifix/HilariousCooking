using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FX_AttentionPulse : MonoBehaviour
{
    public Vector3 init_Pos;
    public Vector3 init_Scale;
    public float frequency =1;
    public float intensity =1;

    private void Start()
    {
        init_Pos = transform.position;
        init_Scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale= init_Scale+Vector3.one*(intensity*Mathf.Cos(Time.time*frequency));
    }
}
