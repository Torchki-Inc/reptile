using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
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
        SceneManager.LoadScene ("Assets/Scenes/Level1/1_1.unity");
        File.Copy("Assets/DataSheets/LizardPlayerData.txt", "Assets/DataSheets/LizardPlayerDataX.txt", true);
    }
}
