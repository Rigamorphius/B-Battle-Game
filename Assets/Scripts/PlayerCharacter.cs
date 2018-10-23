using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour
{

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
    private bool onGround;
    private Collider2D[] groundHitDetection = new Collider2D[20];
    private Checkpoint currentCheckpoint;

    //Bullet Testing
    public GameObject BulletLeft, BulletRight;
    private Vector2 BulletPos;
    public float fireRate;
    private float nextFire;
     private bool facingRight = true;
     private float velX;

    // Use this for initialization
    void Start()
    {

        //Debug.Log("This is start!");
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
        UpdatePhysiceMaterial();
        Move();
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

    private void UpdatePhysiceMaterial()
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
        currentCheckpoint = newCurrentCheckpoint;
    }

    //Shooting Test
    private void Shoot() {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void LateUpdate()
    {
        Vector2 localscale = transform.localScale;
        if (horizontalInput > 0) {
            facingRight = true;
        } else if (horizontalInput < 0) {
            facingRight = false;
        }
        if (((facingRight) && (localscale.x < 0)) || (facingRight) && (localscale.x > 0)){
            localscale.x *= -1;
        }
        transform.localScale = localscale;
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