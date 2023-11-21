using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour
{
    public TextMeshProUGUI counterText;

    public PlayerController dick;

    void Start()
    {
        // Initialize the counter text
        UpdateCounterText();
    }

    void Update()
    {
        UpdateCounterText();
    }

    void UpdateCounterText()
    {
        // Update the text component with the current counter value
        counterText.text = "hp: " + dick.player.hp;
    }
}