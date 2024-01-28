using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ClickToestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Fade(float duration=1) 
    {
        float t = 0;
        while (t < 1) 
        {
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0,t);
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime/ duration;
        }
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown || Input.GetMouseButtonDown(0)) StartCoroutine(Fade());
    }
}
