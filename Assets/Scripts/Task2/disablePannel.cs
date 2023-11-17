using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class disablePannel: MonoBehaviour
{
    public GameObject guide;
    public Image panel;
    public Text text;

    public IEnumerator fade()
    {
        for (float alpha = panel.color.a; alpha > 0; alpha -= 2 * Time.deltaTime)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }

        Destroy(guide);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift")
            StartCoroutine(fade());
    }
}
