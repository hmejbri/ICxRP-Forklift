using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is a part of the ready-made scripts that TGL
 * provided us with. It handles fork controls for the forklift.
 * 
 * Last edited 06/06/2023 By Micael
 *  - Added comments
 *  - **WIP** Added x axis movement of fork rig (Load_Backrest)
 *  - **WIP** Added fork spread movement for the forks
 *  - Rewrote parts of the script to support analog inputs better
 */

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkControl : MonoBehaviour
{
    private VehicleInputProvider inputProvider;
    
    // Variables for backrest movement
    [SerializeField] private Transform forkRig; // Refer to Load_Backrest game object
    [SerializeField] private float maxY;
    [SerializeField] private float maxX;

    // Variables for fork spread movement
    [SerializeField] private Transform forkLeft;
    [SerializeField] private Transform forkRight;
    [SerializeField] private float maxSpread;

    // Fork backrest X movement
    private float forkRigStartX;
    private float forkRigMaxX;
    private float forkRigPosX;

    // Fork backrest Y movement
    private float forkRigStartY;
    private float forkRigMaxY;
    private float forkRigPosY;

    // Fork spread movement
    private float forkSpreadStart;
    private float forkSpreadMax;
    private float forkSpreadPosX;
    private Vector3 forkSpreadPos;

    private float forkInputY => inputProvider.JoystickInput.y;
    private float forkInputX => inputProvider.JoystickInput.x; // Currently used for fork spread, later will be used for backrest X movement

    private void Awake()
    {
        inputProvider = GetComponent<VehicleInputProvider>();
        forkRigStartY = forkRig.position.y + 5f;
        forkRigMaxY = forkRigStartY + maxY;

        forkSpreadStart = forkLeft.position.x;
        forkSpreadMax = forkSpreadStart + maxSpread;
    }
    private void Update()
    {
        forkRigPosY = Mathf.Clamp(forkRigPosY + forkInputY * Time.deltaTime, 0, 1);
        // The Y movement is in Z argument for Vector3 because of the object rotation
        forkRig.transform.localPosition = new Vector3(forkRig.transform.localPosition.x, forkRig.transform.localPosition.y, Mathf.Lerp(forkRigStartY, forkRigMaxY, forkRigPosY));

        // WIP!!
        forkSpreadPosX = Mathf.Clamp(forkSpreadPosX + forkInputX * Time.deltaTime, -1, 1);
        forkLeft.transform.localPosition = new Vector3(forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);
        forkRight.transform.localPosition = new Vector3(-forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);
    }
}
