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

    private void OnTriggerEnter(Collider other)
    {
        if (puzzleManager == null)
        {
            return;
        }

        if (requiredObject == RequiredObject.Racket && other.CompareTag("Racket"))
        {
            puzzleManager.SetRacketPlaced(true);
            Debug.Log("Racket placed correctly.");
        }

        if (requiredObject == RequiredObject.Hat && other.CompareTag("Hat"))
        {
            puzzleManager.SetHatPlaced(true);
            Debug.Log("Hat placed correctly.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (puzzleManager == null)
        {
            return;
        }

        if (requiredObject == RequiredObject.Racket && other.CompareTag("Racket"))
        {
            puzzleManager.SetRacketPlaced(false);
            Debug.Log("Racket removed.");
        }

        if (requiredObject == RequiredObject.Hat && other.CompareTag("Hat"))
        {
            puzzleManager.SetHatPlaced(false);
            Debug.Log("Hat removed.");
        }
    }
}