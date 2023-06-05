using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPallets : MonoBehaviour
{
    public bool grounded = true;
    public bool lifted = false;
    public Transform forklift;

    void Update()
    {
        if (!grounded && lifted)
        {
            Transform p = getParent();

            p.parent = forklift;
        }
    }

    Transform getParent()
    {
        Transform p = this.gameObject.transform;

        while (p.parent)
        {
            if (p.parent == null)
            {
                return p;
            }
            p = p.parent;
        }

        return p;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "forklift")
            lifted = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "rack" || collision.collider.tag == "floor")
            grounded = false;
    }
}
