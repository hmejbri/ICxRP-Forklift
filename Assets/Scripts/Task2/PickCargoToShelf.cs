using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickCargoToShelf : MonoBehaviour
{
    public GameObject guide;
    public Image panel;
    public Text text;
    public GameObject nextstep;
    public GameObject arrow;
    private bool inPlace=false;

    public IEnumerator fade()
    {
        for (float alpha = 0; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, alpha);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }

        yield return new WaitForSeconds(5);

        Destroy(guide);

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cement1")
            inPlace = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "forks" && inPlace == true)
        {
            StartCoroutine(fade());

            GameObject cargo1 = GameObject.Find("cargo1");
            GameObject rack1 = GameObject.Find("rack1");
            cargo1.GetComponent<Outline>().enabled = false;
            rack1.GetComponent<Outline>().enabled = false;
            cargo1.transform.parent = null;
            Destroy(cargo1.transform.GetChild(2).GetComponent<StickPallets>());

            GameObject cargo2 = GameObject.Find("cargo2");
            GameObject rack2 = GameObject.Find("rack2");
            rack2.GetComponent<Outline>().enabled = true;
            cargo2.GetComponent<Outline>().enabled = true;

            nextstep.SetActive(true);
            arrow.SetActive(false);
        }
        //remember fail state

    }
}
