using UnityEngine;

public class CoatRackPuzzleManager : MonoBehaviour
{
    [Header("Puzzle State")]
    public bool racketPlaced = false;
    public bool hatPlaced = false;

    [Header("Objects To Activate When Solved")]
    public GameObject tvClueObject;
    public GameObject successLight;

    [Header("Optional Audio")]
    public AudioSource audioSource;
    public AudioClip successSound;

    private bool puzzleSolved = false;

    public void SetRacketPlaced(bool placed)
    {
        racketPlaced = placed;
        CheckPuzzle();
    }

    public void SetHatPlaced(bool placed)
    {
        hatPlaced = placed;
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        if (puzzleSolved)
        {
            return;
        }

        if (racketPlaced && hatPlaced)
        {
            puzzleSolved = true;
            Debug.Log("Coat rack puzzle solved!");

            if (tvClueObject != null)
            {
                tvClueObject.SetActive(true);
            }

            if (successLight != null)
            {
                successLight.SetActive(true);
            }

            if (audioSource != null && successSound != null)
            {
                audioSource.PlayOneShot(successSound);
            }
        }
    }
}