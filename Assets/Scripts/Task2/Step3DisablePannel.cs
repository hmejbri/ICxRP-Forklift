using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step3DisablePannel : MonoBehaviour
{
    public float duration = 0.4f;
    public Transform forklift;
    public CanvasGroup CG;
    public GameObject nextstep;


    public void fade()
    {
        StartCoroutine(fadeOut(CG, CG.alpha, 0));

    }
    public IEnumerator fadeOut(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
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
        {

            GameObject cargo1 = GameObject.Find("cargo1");
            GameObject rack1 = GameObject.Find("rack1");
            cargo1.GetComponent<Outline>().enabled = false;
            rack1.GetComponent<Outline>().enabled = false;


            GameObject cargo2 = GameObject.Find("cargo2");
            GameObject rack2 = GameObject.Find("rack2");
            rack2.GetComponent<Outline>().enabled = true;
            cargo2.GetComponent<Outline>().enabled = true;


            nextstep.SetActive(true);

            this.gameObject.SetActive(false); 
        
        }
    }
}
