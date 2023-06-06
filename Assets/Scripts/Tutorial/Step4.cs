using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step4: MonoBehaviour
{
    [SerializeField] private Outline target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Transform p = other.transform;

            while (p.parent)
                p = p.parent;

            if (p.tag != "forklift")
            {
                Destroy(gameObject);
                Destroy(target);
            }
        }
    }
}
