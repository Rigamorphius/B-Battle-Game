using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalDoor : MonoBehaviour {
    private bool isPlayerInTrigger;

    private void Update()
    {
        if (Input.GetButtonDown("Activate") && isPlayerInTrigger)
        {
            Debug.Log("Player Activated Door");
            SceneManager.LoadScene("Win");
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
