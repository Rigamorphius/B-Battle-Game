using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float velX = 5f;
    private float velY;
    private Rigidbody2D RB;
    public bool hitGround;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        RB.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }
 

	}

