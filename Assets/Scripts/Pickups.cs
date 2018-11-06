using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour {
    // private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    private static int gemCount;
    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float delay = 0.5f;
        //audioSource.Play();
        if (collision.gameObject.CompareTag("Player")) {
            //Destroy(gameObject,audioSource.clip.length);
            Destroy(gameObject,delay);
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            gemCount++;
            Debug.Log("Gems Collected is = " + gemCount);
        }
    }


}
