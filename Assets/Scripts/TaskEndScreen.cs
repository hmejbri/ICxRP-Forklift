using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/* This script handles the UI for the task end screen.
 * Attached to the Canvas_TaskEndScreen prefab.
 * 
 * Last edited 12/10/2023 by Micael
 */

public class TaskEndScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup; // To control the transparency
    [SerializeField] private Button buttonToDisable;
    [SerializeField] private GameObject leftHand;
    private void Awake()
    {
        // Disable canvas
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        leftHand.SetActive(false);

        // Disables the next scene button if the current scene is task 3 (index 4)
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Debug.Log("Current scene is index 3, next scene button disabled");
            buttonToDisable.interactable = false;
            buttonToDisable.gameObject.SetActive(false);
        }
    }

    public void ShowScreen()
    {
        StartCoroutine(FadeIn());
        canvasGroup.blocksRaycasts = true; // Allow interaction with the UI
        leftHand.SetActive(true);
    }

    IEnumerator FadeIn() // Cosmetic effect
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1f);
            canvasGroup.alpha = alpha;
            yield return null;
        }
    }

    // Button functions; these are attached to the canvas child GameObject buttons
    public void ButtonMainMenu()
    {
        Debug.Log("Main menu button pressed");
        SceneManager.LoadScene(0);
    }

    public void ButtonRestart()
    {
        Debug.Log("Restart button pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonNextScene()
    {
        Debug.Log("Next scene button pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
