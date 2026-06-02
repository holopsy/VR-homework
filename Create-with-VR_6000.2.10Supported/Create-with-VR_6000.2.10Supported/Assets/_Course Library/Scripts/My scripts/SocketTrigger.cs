using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public CoatRackPuzzleManager puzzleManager;

    public enum RequiredObject
    {
        Racket,
        Hat
    }

    public RequiredObject requiredObject;

    private bool alreadyPlaced = false;

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyPlaced || puzzleManager == null)
        {
            return;
        }

        if (requiredObject == RequiredObject.Racket && IsObjectWithTag(other, "Racket"))
        {
            alreadyPlaced = true;
            puzzleManager.SetRacketPlaced(true);
            Debug.Log("Racket placed correctly.");
        }

        if (requiredObject == RequiredObject.Hat && IsObjectWithTag(other, "Hat"))
        {
            alreadyPlaced = true;
            puzzleManager.SetHatPlaced(true);
            Debug.Log("Hat placed correctly.");
        }
    }

    private bool IsObjectWithTag(Collider other, string requiredTag)
    {
        if (other.CompareTag(requiredTag))
        {
            return true;
        }

        Transform parent = other.transform.parent;

        while (parent != null)
        {
            if (parent.CompareTag(requiredTag))
            {
                return true;
            }

            parent = parent.parent;
        }

        return false;
    }
}