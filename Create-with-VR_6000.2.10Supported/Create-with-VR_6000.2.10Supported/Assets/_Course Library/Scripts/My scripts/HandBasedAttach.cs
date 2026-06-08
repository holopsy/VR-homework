using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandBasedAttach : MonoBehaviour
{
    [Header("Attach Points")]
    public Transform rightAttach;
    public Transform leftAttach;

    [Header("Debug")]
    public bool showDebugLogs = true;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("HandBasedAttach needs XRGrabInteractable on the same object.");
        }
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Transform interactorTransform = args.interactorObject.transform;

        if (showDebugLogs)
        {
            Debug.Log("Tablet grabbed by: " + GetFullHierarchyName(interactorTransform));
        }

        if (IsLeftHand(interactorTransform))
        {
            SetAttach(leftAttach, "LEFT");
            return;
        }

        if (IsRightHand(interactorTransform))
        {
            SetAttach(rightAttach, "RIGHT");
            return;
        }

        SetAttach(rightAttach, "RIGHT FALLBACK");
        Debug.LogWarning("Could not detect left/right hand. Using right attach as fallback.");
    }

    private void SetAttach(Transform attachPoint, string side)
    {
        if (attachPoint == null)
        {
            Debug.LogWarning(side + " attach point is missing.");
            return;
        }

        grabInteractable.attachTransform = attachPoint;

        if (showDebugLogs)
        {
            Debug.Log("Using " + side + " attach point: " + attachPoint.name);
        }
    }

    private bool IsLeftHand(Transform t)
    {
        while (t != null)
        {
            string name = t.name.ToLower();

            if (name.Contains("left"))
            {
                return true;
            }

            t = t.parent;
        }

        return false;
    }

    private bool IsRightHand(Transform t)
    {
        while (t != null)
        {
            string name = t.name.ToLower();

            if (name.Contains("right"))
            {
                return true;
            }

            t = t.parent;
        }

        return false;
    }

    private string GetFullHierarchyName(Transform t)
    {
        string fullName = t.name;

        while (t.parent != null)
        {
            t = t.parent;
            fullName = t.name + "/" + fullName;
        }

        return fullName;
    }
}