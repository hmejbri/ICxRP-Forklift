using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleInputProvider : MonoBehaviour
{
    [Header("Main Input")]
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private InputActionReference wheelReference;
    [SerializeField] private InputActionReference throttleReference;
    [SerializeField] private InputActionReference brakeReference;

    [Header("Other Input")]
    [SerializeField] private InputActionReference joystickReference;

    [Header("Debug")]
    [SerializeField] private bool debugEnabled;
    [SerializeField] private TMP_Text debugT;

    private float wheelInput;
    private float throttleInput;
    private float brakeInput;
    private Vector2 joystickInput;

    public float WheelInput => enabled ? wheelInput : 0;
    public float ThrottleInput => enabled ? throttleInput : 0;
    public float BrakeInput => enabled ? brakeInput : 0;
    public Vector2 JoystickInput => enabled ? joystickInput : new Vector2(0, 0);

    private void Awake()
    {
        actionAsset.Enable();
        if (!debugEnabled && debugT)
            debugT.text = " ";
    }
    private void Update()
    {
        if (wheelReference)
            wheelInput = wheelReference.action.ReadValue<Vector2>().x;
        if (throttleReference)
            throttleInput = throttleReference.action.ReadValue<float>();
        if (brakeReference)
            brakeInput = brakeReference.action.ReadValue<float>();
        if (joystickReference)
            joystickInput = joystickReference.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (debugEnabled)
            UpdateDebug();
    }
    private void UpdateDebug() => debugT.text = $"Wheel: {WheelInput:F3}\nThrottle: {ThrottleInput:F3}\nBrake: {BrakeInput:F3}\nJoystick: {JoystickInput}";
}