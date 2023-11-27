using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDataSummary : MonoBehaviour
{
    public PlayerController dick;
    public TextMeshProUGUI dataText;


    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }
    
    void UpdateText()
    {
        // Update the text component with the current counter value
        dataText.text = "hp: " + dick.player.hp + "\nmoveSpeed: " + dick.player.moveSpeed + 
                        "\nfireRate: " + dick.player.fireRate + "\nbalance: " + dick.player.balance + 
                        "\ndamage: " + dick.player.damage + "\nrace: " + dick.player.race /*+
                        "\nitems:\n     positive: " + dick.player.items.positive + "\n     positive: " + dick.player.items.negative*/;
    }
}
