using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StackLargePallets : MonoBehaviour
{
    // this script is added to the green area (the target)
    [SerializeField] private TaskEndScreen taskEndScreen; // For ending UI
    [SerializeField] GameObject sounds;
    [SerializeField] GameObject forklift;

    private int nbPalStacked = 0;

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);

        taskEndScreen.ShowScreen();
        sounds.SetActive(false);
        forklift.GetComponent<ForkControl>().enabled = false;
        forklift.GetComponent<VehicleControl>().enabled = false;
    }

    // if he enters the green area it will count the stacked pallets
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Large pallet")
        {
            nbPalStacked++;

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


