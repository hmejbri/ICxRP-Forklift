using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Step4: MonoBehaviour
{
    [SerializeField] private TaskEndScreen taskEndScreen; // For ending UI
    [SerializeField] GameObject sounds;
    [SerializeField] GameObject forklift;
    [SerializeField] private Outline target;
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);

        FindObjectOfType<GameManager>().stopTimer();
        FindObjectOfType<GameManager>().levelComplete();
        taskEndScreen.ShowScreen();
        sounds.SetActive(false);
        forklift.GetComponent<ForkControl>().enabled = false;
        forklift.GetComponent<VehicleControl>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Transform p = other.transform;

            while (p.parent)
                p = p.parent;

            if (p.tag != "forklift")
            {
                StartCoroutine(FadeIn());
                Destroy(target);

                //destroy all children of the gameobject
                int childs = transform.childCount;
                for (int i = childs - 1; i >= 0; i--)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
    }
}
