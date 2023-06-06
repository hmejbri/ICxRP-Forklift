using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step2: MonoBehaviour
{
    public Text text;
    public Image panel;
    public GameObject step;
    public GameObject nextStep;

    IEnumerator FadeIn()
    {
        for (float alpha = 0f; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            yield return null;
        }

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift" || other.tag == "forks")
        {
            step.SetActive(true);

            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            nextStep.SetActive(true);
            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "forklift" || other.tag == "forks")
        {
            Destroy(step);
            Destroy(gameObject);
        }

    }
}
