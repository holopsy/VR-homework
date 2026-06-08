using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishRoomButton : MonoBehaviour
{
    [Header("Before Completion UI")]
    public GameObject instructionText;
    public GameObject completeButton;

    [Header("End Menu UI")]
    public GameObject endMenuPanel;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip victorySound;
    public AudioClip buttonClickSound;

    private bool completed = false;

    private void Start()
    {
        if (endMenuPanel != null)
        {
            endMenuPanel.SetActive(false);
        }
    }

    public void CompleteRoom()
    {
        if (completed)
        {
            return;
        }

        completed = true;

        if (instructionText != null)
        {
            instructionText.SetActive(false);
        }

        if (completeButton != null)
        {
            completeButton.SetActive(false);
        }

        if (endMenuPanel != null)
        {
            endMenuPanel.SetActive(true);
        }

        if (audioSource != null && victorySound != null)
        {
            audioSource.PlayOneShot(victorySound);
        }

        Debug.Log("Room completed. End menu shown.");
    }

    public void RestartGame()
    {
        PlayButtonClick();

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        PlayButtonClick();

        Debug.Log("Quit Game pressed.");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void PlayButtonClick()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}