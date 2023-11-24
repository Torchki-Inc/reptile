using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameButton : MonoBehaviour
{
    void Start()
    {
        // Assuming you've attached this script to a Button component
        Button NGButton = GetComponent<Button>();

        // Add a listener to the button click event
        NGButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene ("Assets/Scenes/Hub.unity");
    }
}
