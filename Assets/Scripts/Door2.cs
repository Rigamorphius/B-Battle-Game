using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door2 : MonoBehaviour {
    private bool isPlayerInTrigger;

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
        {
            Debug.Log("Player Activated Door");
            SceneManager.LoadScene("Level 3");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
