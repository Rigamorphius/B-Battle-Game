using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public Rigidbody2D CharacterRigid;

	// Use this for initialization
	void Start () {
        Debug.Log("This is start!");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D)) {
            //Moves Character to the right
            CharacterRigid.velocity = new Vector2(5, CharacterRigid.velocity.y);
        }
        //Syntax for printing to the console!
        //Debug.Log("Test");
	}
}
