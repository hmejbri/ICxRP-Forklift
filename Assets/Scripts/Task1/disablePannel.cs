using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class disablePannel: MonoBehaviour
{
    public float duration=0.4f;
    public Transform forklift;
    public CanvasGroup CG;

    
    public void fade()
    {
        StartCoroutine(fadeOut(CG, CG.alpha, 0));

    }
    public IEnumerator fadeOut(CanvasGroup canvasGroup , float start , float end)
    {
        float counter = 0f;
        
        while(counter<duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift")
        {
            fade();

        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "forklift")
            this.gameObject.SetActive(false);
    }

}
