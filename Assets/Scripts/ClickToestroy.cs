using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ClickToestroy : MonoBehaviour
{
    public bool ScriptOnly=false;
    bool isFading=false;
    // Start is called before the first frame update
    public IEnumerator Fade(float duration=1) 
    {
        isFading = true;
        float t = 0;
        if(TryGetComponent<FX_AttentionPulse>(out FX_AttentionPulse FX)) { FX.enabled = false; }
        while (t < 1) 
        {
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0,t);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime/ duration;
            transform.localScale *= 1.01f;
        }
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    
    }

    public void TriggerDisappear() {if(!isFading)StartCoroutine(Fade()); }

    // Update is called once per frame
    void Update()
    {
        if ((Input.anyKeyDown || Input.GetMouseButtonDown(0))&& !ScriptOnly) TriggerDisappear();
    }
}
