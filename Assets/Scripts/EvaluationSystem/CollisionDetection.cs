using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    float time=0;
    bool damaged = false;
    private void OnTriggerEnter(Collider other)
    {   /* if object entered the colliders on the body and the forks of the forklift
           is not a pallet neither another collider of the forklift then an alert appears */
        

        if (other.tag!="step" && other.tag!="pallet" &&
            other.tag!="forklift" && other.tag != "Finish" &&
            other.tag != "Begin" && other.tag != "cargo")
        {

            FindObjectOfType<GameManager>().detectCollision();

            if (damaged && time > 1)
                damaged = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("RedLight").GetComponent<Light>().intensity = 0;
}


}
