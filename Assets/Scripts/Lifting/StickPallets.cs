using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script prevents pallets from dropping from the forks
 * 
 * last editor : Houssem
 */

public class StickPallets : MonoBehaviour
{
    public Transform forklift;

    //keeps count of the times the object collided with the floor or a rack
    private int nbTimes = 0;

    //returns the highest parent of an object 
    Transform getParent()
    {
        Transform p = transform;

        while(p.parent && p.parent.tag != "forklift" && p.parent.tag != "rack" && p.parent.tag != "Begin")
            p = p.parent;

        return p;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "forks" && other.tag != "forklift" && other.tag != "Finish")
        {
            //Test so the objects parents wont be null with the first collision with floor/rack
            if (nbTimes > 0)
            {
                //if the object touches the floor, rack.. then its grounded again so its parent will be set to null
                Transform p = getParent();
                p.parent = null;
            }
            else
                nbTimes++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "forks" && other.tag != "forklift" && other.tag != "Finish")
        {
            //if the object leaves the floor, rack.. then its lifted so its parent will be set to the forklift
            Transform p = getParent();
            p.parent = forklift;
        }
    }

}
