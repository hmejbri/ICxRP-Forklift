using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step4: MonoBehaviour
{
    [SerializeField] private Outline target;
    [SerializeField] private Text text;
    [SerializeField] private Image panel;
    [SerializeField] private GameObject step;
    IEnumerator FadeIn()
    {
       panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 212);
       text.color = new Color(text.color.r, text.color.g, text.color.b, 255);

        yield return new WaitForSeconds(5);

        Destroy(step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Transform p = other.transform;

            while (p.parent)
                p = p.parent;

            if (p.tag != "forklift")
            {
                StartCoroutine(FadeIn());
                Destroy(target);
                //destroy all children of the gameobject
                int childs = transform.childCount;
                for (int i = childs - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
