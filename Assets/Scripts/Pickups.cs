using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
    float score;

    private void Start()
    {
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the Pickup");
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            score = score + 10;
            Debug.Log(score);
            
        }
    }


}
