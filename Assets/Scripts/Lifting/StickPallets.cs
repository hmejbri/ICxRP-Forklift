using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script prevents pallets from dropping from the forks
public class StickPallets : MonoBehaviour
{
    public Transform forklift;

    Transform getParent()
    {
        Transform p = transform;

        while(p.parent && p.parent.tag != "forklift" && p.parent.tag != "rack")
            p = p.parent;

        return p;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "rack" || other.tag == "floor" || other.tag == "cargo")
        {        
            Transform p = getParent();
            p.parent = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "rack" || other.tag == "floor" || other.tag == "cargo")
        {
            Transform p = getParent();
            p.parent = forklift;
        }
    }

}
