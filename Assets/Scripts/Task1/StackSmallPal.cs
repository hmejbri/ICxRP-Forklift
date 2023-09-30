using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StackSmallPal : MonoBehaviour
{ // this script is added to the green area (the target)

    public GameObject LargePallets, RedArea, arrow, NextGuide;
    public Image Panel;
    public Text TextLargeP;
    private int nbPalStacked = 0;

    public IEnumerator Fade()
    {
        for (float alpha = 0; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, alpha);
            TextLargeP.color = new Color(TextLargeP.color.r, TextLargeP.color.g, TextLargeP.color.b, alpha);

            yield return null;
        }

        yield return new WaitForSeconds(4);

        for (float alpha = 212; alpha > 0; alpha -= 2 * Time.deltaTime)
        {
            Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, alpha);
            TextLargeP.color = new Color(TextLargeP.color.r, TextLargeP.color.g, TextLargeP.color.b, alpha);

            yield return null;
        }

        Destroy(NextGuide);
    }

    // if he enters the green area it will count the stacked pallets
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EuroPalette")
        {    
            nbPalStacked++;

            //if the stacked pallets are equal to the pallets laying on the ground |
            // he disable the small pallets and set active the large ones          |
            // -returns to the starting point                                      |
            // -the text of the pannel changes                                     V          

            if (nbPalStacked == 2) {
                StartCoroutine(Fade());
                LargePallets.SetActive(true);
                RedArea.SetActive(true);
                Destroy(arrow);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EuroPalette")
            nbPalStacked--;
    }
}
