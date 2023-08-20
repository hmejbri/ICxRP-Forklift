using UnityEngine;
using UnityEngine.InputSystem;

/* This script handles inputs for the vehicle driving
 * and also includes value references for debugging
 * 
 * Last edited 16/08/2023 By Houssem
 *  - Added control panel input
 */

public class VehicleInputProvider : MonoBehaviour
{
    [Header("Controller Input")]
    [SerializeField] ControllerInput input;

    // Reference: Assets/ScriptableObjects/Inputs/Vehicle Input Actions
    [Header("Main Inputs")]
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private InputActionReference wheelReference;
    [SerializeField] private InputActionReference throttleReference;
    [SerializeField] private InputActionReference brakeReference;

    private float t_wheelInput;
    private float t_throttleInput;
    private float t_brakeInput;
    

    /* If enabled, give t_wheelInput value to wheelInput, otherwise give value 0. Works as a getter
     * to stay updated in runtime. This took me an insanely long time to understand, refer to
     * ternary operators for more info
     * - Micael
     */
    public float wheelInput => enabled ? t_wheelInput : 0;
    public float throttleInput => enabled ? t_throttleInput : 0;
    public float brakeInput => enabled ? t_brakeInput : 0;
    public float forkInputY;
    public float forkInputX;
    public float forkInputSpread;
    public float forkInputTilt;

    private void Awake()
    {
        actionAsset.Enable();
    }
    private void Update()
    {
        if (wheelReference)
            t_wheelInput = wheelReference.action.ReadValue<Vector2>().x;
        if (throttleReference)
            t_throttleInput = input.gearValue * throttleReference.action.ReadValue<float>();
        if (brakeReference)
            t_brakeInput = brakeReference.action.ReadValue<float>();

        forkInputY = input.joystickValues[0];
        forkInputX = input.joystickValues[1];
        forkInputSpread = input.joystickValues[2];
        forkInputTilt = input.joystickValues[3];
    }
}