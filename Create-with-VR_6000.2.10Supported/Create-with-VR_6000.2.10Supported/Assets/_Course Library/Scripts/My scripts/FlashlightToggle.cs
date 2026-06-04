using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlightLight;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip toggleSound;

    private bool isOn = false;

    private void Start()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = false;
        }
    }

    public void ToggleFlashlight()
    {
        isOn = !isOn;

        if (flashlightLight != null)
        {
            flashlightLight.enabled = isOn;
        }

        if (audioSource != null && toggleSound != null)
        {
            audioSource.PlayOneShot(toggleSound);
        }

        Debug.Log("Flashlight toggled: " + isOn);
    }

    public bool IsFlashlightOn()
    {
        return isOn;
    }
}