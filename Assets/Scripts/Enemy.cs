using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    public static int enemyCount;
    private AudioSource audioSource;
    Animator anim;
    private bool isDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && !isDead)
        {
           
            isDead = true;
            audioSource.Play();
            boxCollider2D.enabled = false;           
            enemyCount++;
            Debug.Log("Enemies defeated is = " + enemyCount);
            anim.SetBool("isDead", isDead);
            Destroy(collision.gameObject);
            
        }
    }
}
