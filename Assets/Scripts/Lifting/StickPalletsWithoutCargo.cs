using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickPalletsWithoutCargo : MonoBehaviour
{
    public Transform forklift;
    private int nbTimes = 0;
    private BoxCollider Top, bottom;
    float x, y, z, a, b, c;
    Transform getParent()
    {
        Transform p = transform;

        while (p.parent && p.parent.tag != "forklift" && p.parent.tag != "rack" && p.parent.tag != "Begin")
            p = p.parent;

        return p;
    }
    private void Start()
    {
        Top = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
        x = Top.size.x;
        y = Top.size.y;
        z = Top.size.z;
        bottom = transform.GetChild(1).gameObject.GetComponent<BoxCollider>();
        a = Top.size.x;
        b = Top.size.y;
        c = Top.size.z;
    }
    private void OnTriggerEnter(Collider other)
    {//touches the ground
        if (other.tag != "forks" && other.tag != "forklift" && other.tag != "cargo")
        {
            if (nbTimes > 0)
            {
                Transform p = getParent();
                p.parent = null;
                Top.size = new Vector3(x, y, z);
                //bottom.size = new Vector3(a, b, c);
            }
            else
                nbTimes++;
        }
    }

    private void OnTriggerExit(Collider other)
    {  //leaves the ground
        if (other.tag != "forks" && other.tag != "forklift" && other.tag != "cargo")
        {
            Transform p = getParent();
            p.parent = forklift;
            //get child "Top"
            //make it´s collider bigger
            Top.size = new Vector3(x, 3 * y, z);
            //bottom.size = new Vector3(a, 3 * b, c);

        }
    }
}
   
    

