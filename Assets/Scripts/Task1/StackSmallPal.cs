using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackSmallPal : MonoBehaviour
{ // this script is added to the green area (the target)

    private bool passed = false;
    private int nbPalStacked = 0;
    public int nbPallets=2;
    public GameObject LargePalPannel , EuroPannel;

    public GameObject LargePallets;
    public Transform forklift;
    public Vector3 forkliftStartPos;
    bool _Faded = false;
    public CanvasGroup CanvLargeP;
    public float duration = 0.5f;
    public GameObject greenArea, RedArea;
    public GameObject step3;



    private void Start()
    {
        
       forkliftStartPos = forklift.position;
    }



    public void fade(CanvasGroup CG)
    { 
        StartCoroutine(fadeOut(CG, CG.alpha,_Faded? 0:1));

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
        if (other.name == "EuroPalette")
        { 
            nbPalStacked++;
            Debug.Log(nbPalStacked);

            //if the stacked pallets are equal to the pallets laying on the ground |
            // he disable the small pallets and set active the large ones          |
            // -returns to the starting point                                      |
            // -the text of the pannel changes                                     V
           

            if (nbPalStacked == nbPallets) {
                StartCoroutine(Waiter());
                passed = true;
                Debug.Log("passed !");
                LargePalPannel.SetActive(true);
                step3.SetActive(true);
                EuroPannel.SetActive(false);
                LargePallets.SetActive(true);
                Debug.Log("now red area");

                RedArea.SetActive(true);
            }
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(1);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EuroPalette")
            nbPalStacked--;
    }
}
