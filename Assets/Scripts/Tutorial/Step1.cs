using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step1 : MonoBehaviour
{
    public Text text;
    public Image panel;
    public GameObject step;

    IEnumerator FadeOut()
    {
        for (float alpha = panel.color.a; alpha > 0f; alpha -= 2 * Time.deltaTime)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            yield return null;
        }

        Destroy(step);
        Destroy(gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift")
        {
            StartCoroutine(FadeOut());
        }
    }
}
