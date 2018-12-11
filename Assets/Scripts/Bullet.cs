using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velX;
    private float velY;
    private Rigidbody2D RB;
    private CompositeCollider2D compositeCollider;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        compositeCollider = GetComponent<CompositeCollider2D>();
    }

    void Update()
    {
        RB.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 1f);
        transform.Rotate(new Vector3(0, 0, 1000) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor")) {
            Destroy(gameObject);
        }
    }
}