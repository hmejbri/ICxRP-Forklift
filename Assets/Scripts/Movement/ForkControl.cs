using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VehicleInputProvider))]
public class ForkControl : MonoBehaviour
{
    private VehicleInputProvider inputProvider;
    [SerializeField] private Transform fork;
    [SerializeField] private float maxY;

    private float ogY;
    private float maxLocalY;
    private float forkPos;
    private float ForkInput => inputProvider.JoystickInput.y;


    private void Awake()
    {
        inputProvider = GetComponent<VehicleInputProvider>();
        ogY = fork.localPosition.y;
        maxLocalY = ogY + maxY;
    }
    private void Update()
    {
        forkPos = Mathf.Clamp(forkPos + ForkInput * Time.deltaTime, 0, 1);
        fork.transform.localPosition = new Vector3(fork.transform.localPosition.x, fork.transform.localPosition.y, Mathf.Lerp(ogY, maxLocalY, forkPos));
    }

}
