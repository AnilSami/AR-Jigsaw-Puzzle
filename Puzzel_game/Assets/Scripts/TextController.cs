using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text displayText;
    private bool isTextVisible = false;

    void Start()
    {
        // Initially hide the text
        HideText();
    }

    public void OnButtonClick()
    {
        if (!isTextVisible)
        {
            ShowText();
            Invoke("HideText", 10f); // Hide text after 10 seconds
        }
    }

    private void ShowText()
    {
        isTextVisible = true;
        displayText.gameObject.SetActive(true);
    }

    private void HideText()
    {
        isTextVisible = false;
        displayText.gameObject.SetActive(false);
    }
}
