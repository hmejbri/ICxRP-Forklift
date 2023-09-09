using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackLargePallets : MonoBehaviour
{
     // this script is added to the green area (the target)

   // private bool passed = false;
    private int nbPalStacked = 0;
    public int nbPallets = 2;
    public GameObject GoodJobPannel;

    public GameObject LargePallets;
    public Transform forklift;
    public Vector3 forkliftStartPos;
    bool _Faded = false;
    public CanvasGroup CanvGoodJobP;
    public float duration = 0.5f;
    public GameObject greenArea, RedArea;
    public GameObject step4;



    private void Start()
    {

        forkliftStartPos = forklift.position;
    }



    public void fade(CanvasGroup CG)
    {
        StartCoroutine(fadeOut(CG, CG.alpha, _Faded ? 0 : 1));

    }


    public IEnumerator fadeOut(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }

    }


    /*IEnumerator ExampleCoroutine()
    {
        fade(CanvLargeP);
        EuroPallets.SetActive(false);
        LargePallets.SetActive(true);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(6);
    }
    */


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


            if (nbPalStacked == nbPallets)
            {
               // passed = true;
                Debug.Log("passed !");
                GoodJobPannel.SetActive(true);
                Time.timeScale = 0;
               // step4.SetActive(true);
              
                




            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Large pallet")
            nbPalStacked--;
    }
}


