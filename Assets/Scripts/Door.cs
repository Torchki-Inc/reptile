using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string DestinationScene;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            SceneManager.LoadScene (DestinationScene);
    }
}
