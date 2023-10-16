using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step1Task1 : MonoBehaviour
{
    public Text text1;
    public GameObject step1;
    public Text text2;
    public GameObject step2;

    IEnumerator Fade()
    {
        Image panel1 = step1.GetComponent<Image>();
        Image panel2 = step2.GetComponent<Image>();

        for (float alpha = panel1.color.a; alpha > 0f; alpha -= 2 * Time.deltaTime)
        {
            panel1.color = new Color(panel1.color.r, panel1.color.g, panel1.color.b, alpha);
            text1.color = new Color(text1.color.r, text1.color.g, text1.color.b, alpha);

            yield return null;
        }

        for (float alpha = 0; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            panel2.color = new Color(panel2.color.r, panel2.color.g, panel2.color.b, alpha);
            text2.color = new Color(text2.color.r, text2.color.g, text2.color.b, alpha);
        }

        yield return new WaitForSeconds(4);

        Destroy(step1);
        Destroy(step2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift" || other.tag == "forks")
            StartCoroutine(Fade());
    }
}
