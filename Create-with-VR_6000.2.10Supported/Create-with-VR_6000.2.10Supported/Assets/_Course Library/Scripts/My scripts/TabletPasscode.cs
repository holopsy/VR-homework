using UnityEngine;
using TMPro;

public class TabletPasscode : MonoBehaviour
{
    [Header("Passcode")]
    public string correctCode = "4271";
    private string currentInput = "";

    [Header("UI")]
    public TMP_Text displayText;
    public float normalFontSize = 55f;
    public float successFontSize = 32f;

    [Header("Tablet")]
    public TabletController tabletController;

    [Header("Optional Sound")]
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;

    private bool unlocked = false;

    private void Start()
    {
        UpdateDisplay();
    }

    public void PressNumber(string number)
    {
        if (unlocked)
        {
            return;
        }

        if (currentInput.Length >= 4)
        {
            return;
        }

        currentInput += number;

        if (audioSource != null && buttonSound != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }

        UpdateDisplay();

        if (currentInput.Length == 4)
        {
            CheckCode();
        }
    }

    public void ClearInput()
    {
        if (unlocked)
        {
            return;
        }

        currentInput = "";
        UpdateDisplay();
    }

    private void CheckCode()
    {
        if (currentInput == correctCode)
        {
            unlocked = true;

            if (displayText != null)
            {
                displayText.fontSize = successFontSize;
                displayText.text = "CORRECT PASSCODE\nPLACE TABLET\nNEAR THE DOOR";
            }

            if (tabletController != null)
            {
                tabletController.UnlockTablet();
            }

            if (audioSource != null && correctSound != null)
            {
                audioSource.PlayOneShot(correctSound);
            }

            Debug.Log("Correct tablet passcode.");
        }
        else
        {
            if (audioSource != null && wrongSound != null)
            {
                audioSource.PlayOneShot(wrongSound);
            }

            currentInput = "";
            UpdateDisplay();

            Debug.Log("Wrong tablet passcode.");
        }
    }

    private void UpdateDisplay()
    {
        if (displayText == null)
        {
            return;
        }

        displayText.fontSize = normalFontSize;

        string hiddenInput = "";

        for (int i = 0; i < 4; i++)
        {
            if (i < currentInput.Length)
            {
                hiddenInput += currentInput[i] + " ";
            }
            else
            {
                hiddenInput += "_ ";
            }
        }

        displayText.text = "ENTER PASSCODE\n" + hiddenInput;
    }
}