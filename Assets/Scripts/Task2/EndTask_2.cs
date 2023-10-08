using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTask_2 : MonoBehaviour
{
    public GameObject cargo2;
    public GameObject guide;
    public Image panel;
    public Text text;
    public GameObject arrow;
    private bool inPlace = false;
    public IEnumerator fade()
    {
        for (float alpha = 0; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
        
        yield return new WaitForSeconds(3);

        Destroy(guide);
        Time.timeScale = 0;

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cement2")
        {
            inPlace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="forks" && inPlace == true)
        {
            StartCoroutine(fade());
            arrow.SetActive(false);
            cargo2.transform.parent = null;
            Destroy(cargo2.transform.GetChild(2).GetComponent<StickPallets>());
        }
    }
}
