using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public new AudioSource audio;
  public AudioClip dab;

  //ADVANCED JUMPING TEST REEEEEEEEEEEE
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;
  bool jump = false;
  bool jumpCancel = false;

  public float moveSpeed;
  public float jumpForce;
  public CharacterController controller;

  private Vector3 moveDirection;
  public float gravityScale;

  public Animator anim;
  public Transform pivot;
  public float rotateSpeed;

  public GameObject playerModel;

  public float knockBackForce;
  public float knockBackTime;
  private float knockBackCounter;

	// Use this for initialization
	void Start () {
    controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

    //knockback checking, if not knocking back then we can move
    if (knockBackCounter <= 0)
    {
      float yStore = moveDirection.y;
      moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
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
    } else
    {
      knockBackCounter -= Time.deltaTime;
    }

    //moves stuff in certain directions
    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
    controller.Move(moveDirection * Time.deltaTime);

    //Move the player in different directions based on camera look direction
    if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    {
      transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
      Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
      playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    //Animation parameters
    anim.SetBool("isGrounded", controller.isGrounded);
    anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    //Dabbing
    if (Input.GetButtonDown("Fire1"))
    {
      anim.SetBool("isDabbing", true);
      Debug.Log("I'm supposed to be dabbing");
    } else if(Input.GetButtonUp("Fire1"))
    {
      anim.SetBool("isDabbing", false);
    }

    //advanced jumping testing
    if (Input.GetButtonDown("Jump") && controller.isGrounded)
    {
      jump = true;
    }
    if(Input.GetButtonUp("Jump") && !controller.isGrounded)
    {
      jumpCancel = true;
    }

  }

  public void Knockback(Vector3 direction)
  {
    knockBackCounter = knockBackTime;

    moveDirection = direction * knockBackForce;
    moveDirection.y = knockBackForce;
  }

  //TESTING WALL JUMP*********************************
  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (!controller.isGrounded && hit.normal.y < 0.1f)
    {
      if (Input.GetButtonDown("Jump"))
      {
        Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
        moveDirection.y = jumpForce;
        //???
      }
    }
  }

}
