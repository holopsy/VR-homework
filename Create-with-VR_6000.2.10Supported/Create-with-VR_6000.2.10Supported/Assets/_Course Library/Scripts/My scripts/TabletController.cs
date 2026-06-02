using UnityEngine;

public class TabletController : MonoBehaviour
{
    [Header("Screen")]
    public Renderer screenRenderer;
    public Material offMaterial;
    public Material onMaterial;

    [Header("UI")]
    public GameObject keypadPanel;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip powerOnSound;
    public AudioClip powerOffSound;

    private bool isOn = false;
    private bool isUnlocked = false;

    private void Start()
    {
        isOn = false;

        if (screenRenderer != null && offMaterial != null)
        {
            screenRenderer.material = offMaterial;
        }

        if (keypadPanel != null)
        {
            keypadPanel.SetActive(false);
        }

        Debug.Log("Tablet starts OFF");
    }

    public void ToggleScreen()
    {
        Debug.Log("ToggleScreen pressed. Current isOn = " + isOn);

        if (isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        isOn = true;

        if (screenRenderer != null && onMaterial != null)
        {
            screenRenderer.material = onMaterial;
        }

        if (keypadPanel != null)
        {
            keypadPanel.SetActive(true);
        }

        if (audioSource != null && powerOnSound != null)
        {
            audioSource.PlayOneShot(powerOnSound);
        }

        Debug.Log("Tablet screen ON");
    }

    public void TurnOff()
    {
        isOn = false;

        if (screenRenderer != null && offMaterial != null)
        {
            screenRenderer.material = offMaterial;
        }

        if (keypadPanel != null)
        {
            keypadPanel.SetActive(false);
        }

        if (audioSource != null && powerOffSound != null)
        {
            audioSource.PlayOneShot(powerOffSound);
        }

        Debug.Log("Tablet screen OFF");
    }

    public void UnlockTablet()
    {
        isUnlocked = true;
        Debug.Log("Tablet unlocked.");
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }
}