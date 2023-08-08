using System.Collections;
using UnityEngine;

public class recenterOrigin : MonoBehaviour
{
    [SerializeField] Transform resetTransform;
    [SerializeField] GameObject player;
    [SerializeField] Camera playerHead;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasTarget;

    IEnumerator Recenter()
    {
        yield return new WaitForSeconds(.5f);
        var rotationAngleY = playerHead.transform.rotation.eulerAngles.y - resetTransform.rotation.eulerAngles.y;
        player.transform.Rotate(0, - rotationAngleY, 0);

        var distanceDiff = resetTransform.position - playerHead.transform.position;
        player.transform.position += distanceDiff;

        canvas.transform.position = canvasTarget.transform.position;
        canvas.transform.rotation = canvasTarget.transform.rotation;

        yield return null;
    }

    void Start()
    {
        StartCoroutine(Recenter()); 
    }
}
