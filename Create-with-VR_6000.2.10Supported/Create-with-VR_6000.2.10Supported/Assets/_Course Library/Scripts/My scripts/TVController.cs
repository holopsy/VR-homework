using UnityEngine;

public class TVController : MonoBehaviour
{
    [Header("TV Screen")]
    public Renderer screenRenderer;
    public Material offMaterial;
    public Material onMaterial;

    [Header("TV Clue")]
    public GameObject clueText;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip tvOnSound;

    private bool isOn = false;

    private void Start()
    {
        TurnOff();
    }

    public void TurnOn()
    {
        if (isOn)
        {
            return;
        }

        isOn = true;

        if (screenRenderer != null && onMaterial != null)
        {
            screenRenderer.material = onMaterial;
        }

        if (clueText != null)
        {
            clueText.SetActive(true);
        }

        if (audioSource != null && tvOnSound != null)
        {
            audioSource.PlayOneShot(tvOnSound);
        }

        Debug.Log("TV turned on.");
    }

    public void TurnOff()
    {
        isOn = false;

        if (screenRenderer != null && offMaterial != null)
        {
            screenRenderer.material = offMaterial;
        }

        if (clueText != null)
        {
            clueText.SetActive(false);
        }
    }
}