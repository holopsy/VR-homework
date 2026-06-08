using UnityEngine;

public class GameStartController : MonoBehaviour
{
    [Header("UI")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject inGameSettingsButton;

    [Header("Gameplay objects/components to enable when game starts")]
    public Behaviour[] componentsToEnableOnStart;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip startSound;
    public AudioClip buttonClickSound;

    private bool gameStarted = false;

    private void Start()
    {
        gameStarted = false;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (inGameSettingsButton != null)
            inGameSettingsButton.SetActive(false);

        SetGameplayComponents(false);
    }

    public void StartGame()
    {
        if (gameStarted)
            return;

        gameStarted = true;

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (inGameSettingsButton != null)
            inGameSettingsButton.SetActive(true);

        SetGameplayComponents(true);

        if (audioSource != null && startSound != null)
            audioSource.PlayOneShot(startSound);

        Debug.Log("Game started. Gameplay interactions enabled.");
    }

    public void ShowSettings()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(true);

        PlayButtonSound();
    }

    public void BackToMenu()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (!gameStarted && mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (gameStarted && inGameSettingsButton != null)
            inGameSettingsButton.SetActive(true);

        PlayButtonSound();
    }

    private void SetGameplayComponents(bool enabled)
    {
        foreach (Behaviour component in componentsToEnableOnStart)
        {
            if (component != null)
            {
                component.enabled = enabled;
            }
        }
    }

    private void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound);
    }
}