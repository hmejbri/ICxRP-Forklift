using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is a part of the ready-made scripts that TGL
 * provided us with. It handles fork controls for the forklift.
 * 
 * Last edited 03/06/2023 By Micael
 *  - Removed lerping function from forkRigY movement
 *  - Added adjustable variable for forkRigY speed
 *  - Cleaned up code a bit
 */

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkControl : MonoBehaviour
{
    private VehicleInputProvider inputProvider;

    // Adjustable variables for backrest movement
    [SerializeField] private Transform forkRig; // Refer to Load_Backrest game object
    [SerializeField] private float forkRigAdjustMaxY = 3f; // 3f is just an estimate for max height
    [SerializeField] private float forkRigAdjustMaxX;
    [SerializeField] private float forkRigSpeedY = 1f; // Adjust this to change speed

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
        forkRigMaxY = forkRigStartY + forkRigAdjustMaxY;
        forkSpreadMax = forkSpreadStart + maxSpread;
    }
    private void Update()
    {
        forkRigPosY = Mathf.Clamp(forkRigPosY + forkInputY * Time.deltaTime * forkRigSpeedY, forkRigStartY, forkRigMaxY);
        // The Y movement is in Z argument for Vector3 because of the object rotation
        forkRig.transform.localPosition = new Vector3(forkRig.transform.localPosition.x, forkRig.transform.localPosition.y, forkRigPosY * 5f);

        // WIP!!
        forkSpreadPosX = Mathf.Clamp(forkSpreadPosX + forkInputX * Time.deltaTime, -1, 1);
        forkLeft.transform.localPosition = new Vector3(forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);
        forkRight.transform.localPosition = new Vector3(-forkSpreadPosX, forkLeft.transform.localPosition.y, forkLeft.transform.localPosition.z);
    }
}