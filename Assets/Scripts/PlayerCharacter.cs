using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D CharacterRigid;

    [SerializeField]
 private float Speed = 2;

    private float moveInput;

    // Use this for initialization
    void Start () {

        //Debug.Log("This is start!");
	}
	
	// Update is called once per frame
	void Update () {
        GetMovementInput();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void GetMovementInput() {
        moveInput = Input.GetAxis("Horizontal");

    }
    private void Move()
    {

    }

    private void Jump()
    {
        //TODO: Make the Character Jump
    }
}
