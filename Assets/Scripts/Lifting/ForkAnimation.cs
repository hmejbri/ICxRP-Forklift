using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkAnimation : MonoBehaviour
{
    [SerializeField] VehicleInputProvider inputProvider;
    [SerializeField] GameObject lever1;

    private float forkInputY => inputProvider.JoystickInput.y;

    // Update is called once per frame
    void Update()
    {
        if(forkInputY != 0)
            lever1.transform.Rotate(lever1.transform.rotation.x + forkInputY, lever1.transform.rotation.y, lever1.transform.rotation.z, Space.Self);
    }
}
