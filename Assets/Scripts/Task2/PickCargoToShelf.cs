using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCargoToShelf : MonoBehaviour
{
    [SerializeField] GameObject cargoShelfToShelfGuide;
    [SerializeField] GameObject nextStep;
    private bool inplace=false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="cargo1")
        {
            Debug.Log("the cargo is successfully in the box");
            inplace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("the "+other.name + " out of the step 2");
        

            if (other.name!="cargo1"&& inplace==true)
        {
           
            cargoShelfToShelfGuide.SetActive(true);
            nextStep.SetActive(true);
            
        }
        //remember fail state

    }
}
