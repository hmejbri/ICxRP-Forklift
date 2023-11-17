using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3DisablePanel : MonoBehaviour
{
    public GameObject guide;
    public CanvasGroup CG;

    IEnumerator FadeOut() // Cosmetic effect
    {
        float elapsedTime = 1f;

        while (elapsedTime > 0f)
        {
            elapsedTime -= Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime);
            CG.alpha = alpha;
            yield return null;
        }

        Destroy(guide);
        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "forklift")
            StartCoroutine(FadeOut());
    }
}
