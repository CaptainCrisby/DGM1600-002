using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public float moveSpeed;
  public float jumpForce;
  public CharacterController controller;

  private Vector3 moveDirection;
  public float gravityScale;

	// Use this for initialization
	void Start () {
    controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

    float yStore = moveDirection.y;
    moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
    //this makes it so that if we were to go diagonal that the movement speed isn't doubled.
    moveDirection = moveDirection.normalized * moveSpeed;
    moveDirection.y = yStore;

    //if the player is grounded, jump. Also sets the jumpforce.
    if (controller.isGrounded)
    {
      moveDirection.y = 0f;
      if (Input.GetButtonDown("Jump"))
      {
        moveDirection.y = jumpForce;
      }
    }

    //moves stuff in certain directions
    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
    controller.Move(moveDirection * Time.deltaTime);

    }
}
