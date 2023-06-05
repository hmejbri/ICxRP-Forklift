using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script prevents pallets from dropping from the forks
public class StickPallets : MonoBehaviour
{
    public Transform forklift;
    private int nbTimes = 0;

    Transform getParent()
    {
        Transform p = transform;

        while(p.parent && p.parent.tag != "forklift" && p.parent.tag != "rack" && p.parent.tag != "Begin")
            p = p.parent;

        return p;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "forks" && other.tag != "forklift")
        {
            if (nbTimes > 0)
            {
                Transform p = getParent();
                p.parent = null;
            }else
                nbTimes++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "forks" && other.tag != "forklift")
        {
            Transform p = getParent();
            p.parent = forklift;
        }
    }

}
