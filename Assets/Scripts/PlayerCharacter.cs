﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{

    private Collider2D[] groundHitDetection = new Collider2D[20];
    private Checkpoint currentCheckpoint;
    public GameObject BulletLeft, BulletRight;
    private Vector2 BulletPos;
    public float fireRate;
    private float nextFire;
    private bool facingRight = true;


    Animator anim;
   public bool onGround;

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

    [SerializeField]
    private PhysicsMaterial2D playerMoving, playerStopping;

    [SerializeField]
    private Collider2D playerGroundCollider;

    private float horizontalInput;




    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetJump();
        IsOnGround();
        Shoot();
    }

    private void FixedUpdate()
    {
       
        anim.SetBool("onGround", onGround);
        UpdatePhysicsMaterial();
        Move();
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();

        }
    }

    private void GetMovementInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

 
    private void Move()
    {
        CharacterRigid.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = CharacterRigid.velocity;
        clampedVelocity.x = Mathf.Clamp(CharacterRigid.velocity.x, -maxSpeed, maxSpeed);
        CharacterRigid.velocity = clampedVelocity;
    }

   private void GetJump()
    {
        if (Input.GetButtonDown("Jump") && onGround)
       {
           CharacterRigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
       }
   }

   private void IsOnGround()
   {
        onGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundHitDetection) > 0;
       //Debug.Log("IsOnGround?: " + onGround);
    }

    private void UpdatePhysicsMaterial()
    {
        if (Mathf.Abs(horizontalInput) > 0)
        {
            playerGroundCollider.sharedMaterial = playerMoving;
        }
        else
        {
            playerGroundCollider.sharedMaterial = playerStopping;
        }
    }

    public void Respawn() {
        if (currentCheckpoint == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else {
            transform.position = currentCheckpoint.transform.position;
            CharacterRigid.velocity = Vector2.zero;
        }
    }

    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {
        if(currentCheckpoint != null) 
            currentCheckpoint.SetIsActivated(false);

            currentCheckpoint = newCurrentCheckpoint;
            currentCheckpoint.SetIsActivated(true);
        
        
    }

    private void Shoot() {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            Fire();
        }
    }

   private void Flip()
   {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Fire()
    {
        BulletPos = transform.position;

        if (facingRight)
        {
            BulletPos += new Vector2(+1f, -0.01f);
            Instantiate(BulletRight, BulletPos, Quaternion.identity);
        }
        else
        {
            BulletPos += new Vector2(-1f, 0.01f);
            Instantiate(BulletLeft, BulletPos, Quaternion.identity);
        }
    }

    

}