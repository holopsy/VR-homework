using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    [Header("Victory UI")]
    public GameObject victoryCanvas;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip victorySound;

    private bool escaped = false;

    private void Start()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (escaped)
        {
            return;
        }

        if (IsPlayer(other))
        {
            escaped = true;

            if (victoryCanvas != null)
            {
                victoryCanvas.SetActive(true);
            }

            if (audioSource != null && victorySound != null)
            {
                audioSource.PlayOneShot(victorySound);
            }

            Debug.Log("Player escaped!");
        }
    }

    private bool IsPlayer(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return true;
        }

        if (other.GetComponentInParent<Unity.XR.CoreUtils.XROrigin>() != null)
        {
            return true;
        }

        if (other.GetComponentInParent<Camera>() != null)
        {
            return true;
        }

        return false;
    }
}