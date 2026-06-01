using UnityEngine;

public class MirrorClueReveal : MonoBehaviour
{
    [Header("Objects")]
    public GameObject clueText;
    public FlashlightToggle flashlight;

    [Header("Settings")]
    public bool hideWhenFlashlightLeaves = false;

    private void OnTriggerStay(Collider other)
    {
        if (flashlight == null || clueText == null)
        {
            return;
        }

        if (other.GetComponentInParent<FlashlightToggle>() == flashlight && flashlight.IsFlashlightOn())
        {
            clueText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!hideWhenFlashlightLeaves)
        {
            return;
        }

        if (other.GetComponentInParent<FlashlightToggle>() == flashlight)
        {
            clueText.SetActive(false);
        }
    }
}