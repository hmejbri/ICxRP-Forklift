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
        if(other.name=="cargo1"||other.tag=="pallet"|| other.tag == "cargo" )
        {
            Debug.Log("the cargo is successfully in the box");
            inplace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
      
        

            if (other.tag=="forks" && inplace==true)
        {
           
            cargoShelfToShelfGuide.SetActive(true);
            nextStep.SetActive(true);
            
        }
        //remember fail state

    }
}
