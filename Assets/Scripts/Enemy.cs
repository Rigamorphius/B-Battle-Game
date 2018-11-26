using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    public static int enemyCount;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            Destroy(gameObject);
            enemyCount++;
            Debug.Log("Enemies defeated is = " + enemyCount);
        }
    }
}
