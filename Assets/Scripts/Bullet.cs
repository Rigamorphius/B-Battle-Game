using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velX = 5f;
    private float velY = 0;
    private Rigidbody2D RB;
    private CompositeCollider2D compositeCollider;

    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        compositeCollider = GetComponent<CompositeCollider2D>();
    }

    // Update is called once per frame
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

