using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StackLargePallets : MonoBehaviour
{
    // this script is added to the green area (the target)

    public GameObject GoodJobGuide, Sounds;
    public Image GoodJobPanel;
    public Text GoodJobText;
    private int nbPalStacked = 0;

    public IEnumerator Fade()
    {
        for (float alpha = 0; alpha < 212; alpha += 2 * Time.deltaTime)
        {
            GoodJobPanel.color = new Color(GoodJobPanel.color.r, GoodJobPanel.color.g, GoodJobPanel.color.b, alpha);
            GoodJobText.color = new Color(GoodJobText.color.r, GoodJobText.color.g, GoodJobText.color.b, alpha);
        }

        yield return new WaitForSeconds(1);
        Destroy(Sounds);
        Time.timeScale = 0;
    }

    // if he enters the green area it will count the stacked pallets
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Large pallet")
        {
            nbPalStacked++;
            Debug.Log(nbPalStacked);

            //if the stacked pallets are equal to the pallets laying on the ground |
            // he disable the small pallets and set active the large ones          |
            // -returns to the starting point                                      |
            // -the text of the pannel changes                                     V          

            if (nbPalStacked == 2)
                StartCoroutine(Fade());
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Large pallet")
            nbPalStacked--;
    }
}


