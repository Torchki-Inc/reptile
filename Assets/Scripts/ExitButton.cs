using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour
{
    // Attach this script to your button GameObject

    void Start()
    {
        // Assuming you've attached this script to a Button component
        Button closeButton = GetComponent<Button>();

        // Add a listener to the button click event
        closeButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // This function will be called when the button is clicked
        Debug.Log("Closing game...");
        Application.Quit(); // Note: This will only work in a standalone build, not in the Unity Editor
    }
}