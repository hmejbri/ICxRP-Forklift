using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script prevents pallets from dropping from the forks
public class StickPallets : MonoBehaviour
{
    public Transform forklift;
    private int nbTimes = 0;
    public BoxCollider Top, bottom;
    float x, y, z, a, b, c;


    Transform getParent()
    {
        Transform p = transform;

        while(p.parent && p.parent.tag != "forklift" && p.parent.tag != "rack" && p.parent.tag != "Begin")
            p = p.parent;

        return p;
    }



    private void Start()
    {
        
        bottom = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        a= bottom.size.x;
        b = bottom.size.y;
        c= bottom.size.z;
    }


    private void OnTriggerEnter(Collider other)
    {//touches the ground
        if (other.tag != "forks" && other.tag != "forklift" && other.tag != "cargo")
        {
            if (nbTimes > 0)
            {
                Debug.Log(other.name);
                Transform p = getParent();
                p.parent = null;
                
                bottom.size = new Vector3(a,b,c);
            }
            else
                nbTimes++;
        }
    }

    private void OnTriggerExit(Collider other)
    {  //leaves the ground
        if (other.tag != "forks" && other.tag != "forklift" )
        {
            Transform p = getParent();
            p.parent = forklift;
            //get child "bottom"
            //make it´s collider bigger so it can detect the ground properly
         
            bottom.size = new Vector3(a, 2*b, c);

        }
    }

}
