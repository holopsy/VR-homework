using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlightLight;

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

        Debug.Log("Flashlight toggled: " + isOn);
    }

    public bool IsFlashlightOn()
    {
        return isOn;
    }
}