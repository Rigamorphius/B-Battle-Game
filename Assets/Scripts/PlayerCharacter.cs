using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D CharacterRigid;

    [SerializeField]
    private float accelerationForce = 5;

    [SerializeField]
    private ContactFilter2D groundContactFilter;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float maxSpeed = 5;

    [SerializeField]
    private Collider2D groundDetectTrigger;

    private float horizontalInput;
    private bool onGround;
    private Collider2D[] groundHitDetection = new Collider2D[20];

    // Use this for initialization
    void Start () {

        //Debug.Log("This is start!");
	}
	
	// Update is called once per frame
	void Update () {  
        GetMovementInput();
        GetJump();
        IsOnGround();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        
    }

    private void Move() {
        CharacterRigid.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = CharacterRigid.velocity;
        clampedVelocity.x = Mathf.Clamp(CharacterRigid.velocity.x, -maxSpeed, maxSpeed);
        CharacterRigid.velocity = clampedVelocity;
    }
    
    private void GetJump()
    {
        if (Input.GetButtonDown("Jump") && onGround) {
            CharacterRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void IsOnGround() {
      onGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetection) > 0;
        //Debug.Log("IsOnGround?: " + onGround);
    }
    
    }

