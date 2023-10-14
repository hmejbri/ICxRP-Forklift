using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTask_2 : MonoBehaviour
{
    [SerializeField] private TaskEndScreen taskEndScreen; // For ending UI
    [SerializeField] GameObject sounds;
    [SerializeField] GameObject forklift;

    public GameObject cargo2;
    public GameObject arrow;
    private bool inPlace = false;
    public IEnumerator fade()
    {
        yield return new WaitForSeconds(1);

        taskEndScreen.ShowScreen();
        sounds.SetActive(false);
        forklift.GetComponent<ForkControl>().enabled = false;
        forklift.GetComponent<VehicleControl>().enabled = false;

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cement2")
        {
            inPlace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="forks" && inPlace == true)
        {
            StartCoroutine(fade());
            arrow.SetActive(false);
            cargo2.transform.parent = null;
            Destroy(cargo2.transform.GetChild(2).GetComponent<StickPallets>());
        }
    }
}
