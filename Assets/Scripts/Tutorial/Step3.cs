using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step3: MonoBehaviour
{
    public Text text;
    public Image panel;
    public GameObject step;
    public GameObject step4;
    private bool startedCoroutine = false;
    private string[] stepsText =
        { "-Use the first lever to move the forks\r\nup and down.",
        "-Use the second lever to tilt the forks\r\nforward and backward.",
        "-Use the third lever to move the forks\r\nleft and right.",
        "-Use the forth lever to open and close\r\nthe forks.",
        "Now to showcase what you learned lift the\r\noutlined cargo to the green area."};

    private void Update()
    {
        if (panel.color.a > 0 && !startedCoroutine)
        {
            startedCoroutine = true;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);

        for (int i = 1; i < stepsText.Length; i++)
        {
            if(i < stepsText.Length - 1)
                text.text = "Moving on to the forklift controls :\r\n" + stepsText[i];
            else
                text.text = stepsText[i];

            yield return new WaitForSeconds(5);
        }

        step4.SetActive(true);
    }

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
        if (other.tag == "forks" || other.tag == "forklift")
        {
            step.SetActive(true);

            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "forks" || other.tag == "forklift")
        {
            Destroy(step);
            Destroy(gameObject);
        }

    }
}
