using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TabletSocketDoorUnlock : MonoBehaviour
{
    [Header("Door")]
    public Transform door;
    public Vector3 openRotation = new Vector3(0f, 90f, 0f);
    public float openSpeed = 2f;

    [Header("Socket")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;

    [Header("Optional Feedback")]
    public GameObject lockedMessage;
    public GameObject successMessage;
    public AudioSource audioSource;
    public AudioClip lockedSound;
    public AudioClip unlockSound;
    public AudioClip doorOpenSound;

    private bool doorOpened = false;
    private Quaternion targetRotation;

    private void Start()
    {
        if (door != null)
        {
            targetRotation = Quaternion.Euler(door.eulerAngles + openRotation);
        }

        if (lockedMessage != null)
        {
            lockedMessage.SetActive(false);
        }

        if (successMessage != null)
        {
            successMessage.SetActive(false);
        }

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnTabletSocketed);
        }
    }

    private void OnDestroy()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnTabletSocketed);
        }
    }

    private void Update()
    {
        if (doorOpened && door != null)
        {
            door.rotation = Quaternion.Slerp(
                door.rotation,
                targetRotation,
                Time.deltaTime * openSpeed
            );
        }
    }

    private void OnTabletSocketed(SelectEnterEventArgs args)
    {
        if (doorOpened)
        {
            return;
        }

        TabletController tablet = args.interactableObject.transform.GetComponentInParent<TabletController>();

        if (tablet == null)
        {
            return;
        }

        if (tablet.IsUnlocked())
        {
            OpenDoor();
        }
        else
        {
            ShowLockedFeedback();
        }
    }

    private void OpenDoor()
    {
        doorOpened = true;

        if (successMessage != null)
        {
            successMessage.SetActive(true);
        }

        if (audioSource != null)
        {
            if (unlockSound != null)
            {
                audioSource.PlayOneShot(unlockSound);
            }

            if (doorOpenSound != null)
            {
                audioSource.PlayOneShot(doorOpenSound);
            }
        }

        Debug.Log("Door opened after unlocked tablet was socketed.");
    }

    private void ShowLockedFeedback()
    {
        if (lockedMessage != null)
        {
            lockedMessage.SetActive(true);
        }

        if (audioSource != null && lockedSound != null)
        {
            audioSource.PlayOneShot(lockedSound);
        }

        Debug.Log("Tablet is locked. Socket accepted it, but door did not open.");
    }
}