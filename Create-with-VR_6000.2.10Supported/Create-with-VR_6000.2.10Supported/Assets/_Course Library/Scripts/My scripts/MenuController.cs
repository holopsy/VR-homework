using UnityEngine;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    [Header("Optional Game Objects")]
    public GameObject startMenuCanvas;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    private void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        PlayClickSound();

        if (startMenuCanvas != null)
        {
            startMenuCanvas.SetActive(false);
        }

        Debug.Log("Game started.");
    }

    public void ShowSettings()
    {
        PlayClickSound();

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    public void ShowMainMenu()
    {
        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }

        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        PlayClickSound();
        ShowMainMenu();
    }

    private void PlayClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}