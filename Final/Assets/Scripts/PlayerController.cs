using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public new AudioSource audio;
  public AudioClip dab;
  private bool isDabbing;

  public float moveSpeed;
  float walkSpeed = 10;
  float runSpeed = 15;

  public float jumpForce;
  float minJumpForce = 10;
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

  public Transform shadow;
  public LayerMask ignoreLayer;

  // Use this for initialization
  void Start () {
    controller = GetComponent<CharacterController>();
    isDabbing = false;
	}
	
	// Update is called once per frame
	void Update () {

    //de-parents the player from a moving object
    if (!controller.isGrounded)
    {
      transform.parent = null;
    }


    //knockback checking, if not knocking back then we can move
    if (knockBackCounter <= 0)
    {
      float yStore = moveDirection.y;
      moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
      //this makes it so that if we were to go diagonal that the movement speed isn't doubled.
      moveDirection = moveDirection.normalized * moveSpeed;
      moveDirection.y = yStore;

      //if the player is grounded, jump. Also sets the jumpforce.
      if (IsGrounded())
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
    //jumps the minimum value
    if (Input.GetButtonUp("Jump"))
    {
      if (moveDirection.y > minJumpForce)
      {
        moveDirection.y = minJumpForce;
      }
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
    anim.SetBool("isGrounded", IsGrounded());
    anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    //Dabbing
    if (Input.GetButtonDown("Fire1"))
    {
      anim.SetBool("isDabbing", true);
      isDabbing = true;
    } else if(Input.GetButtonUp("Fire1"))
    {
      anim.SetBool("isDabbing", false);
      isDabbing = false;
    }

    //Dabbing Run
    if (isDabbing == true)
    {
      moveSpeed = runSpeed;
    } else if (isDabbing == false)
    {
      moveSpeed = walkSpeed;
    }

    UpdateShadow();

  }

  //Updates the player's shadow based on their shadow
  private void UpdateShadow()
  {
    RaycastHit hit;
    Physics.Raycast(transform.position, Vector3.down, out hit, ignoreLayer);
    shadow.position = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
  }

  //sets the radio dance idle to true
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Radio")
    {
      anim.SetBool("isNearRadio", true);
    }
  }
  //sets the radio dance idle to false
  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Radio")
    {
      anim.SetBool("isNearRadio", false);
    }

    if (other.gameObject.tag == "WallJump")
    {
      anim.SetBool("isSliding", false);
    }
  }


  public void Knockback(Vector3 direction)
  {
    knockBackCounter = knockBackTime;

    moveDirection = direction * knockBackForce;
    moveDirection.y = knockBackForce;
  }

  //Helps when going down slopes that he isn't "falling" and instead he snaps to it
  private bool IsGrounded()
  {
    if (controller.isGrounded)
      return true;

    Vector3 bottom = controller.transform.position - new Vector3(0, controller.height / 2, 0);

    RaycastHit hit;
    if (Physics.Raycast(bottom, new Vector3(0, -1, 0), out hit, .3f) && hit.transform.tag != "NoCollide")
    {
      controller.Move(new Vector3(0, -hit.distance, 0));
      return true;
    }
    return false;
  }

  //Wall jumping
  private void OnControllerColliderHit(ControllerColliderHit hit)
  {
    if (!controller.isGrounded && hit.normal.y < 0.1f && hit.normal.y > -0.1f)
    {
      anim.SetBool("isSliding", true);
      anim.SetBool("isWallJumping", false);

      if (Input.GetButtonDown("Jump"))
      {
        Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);

        //lets him jump on walls
        knockBackCounter = knockBackTime;

        moveDirection = hit.normal * knockBackForce;
        moveDirection.y = knockBackForce;
        anim.SetBool("isWallJumping", true);
        anim.SetBool("isSliding", false);
      }
    }

    //moving platform makes the player "stick" to it and keep the transformations
    if (hit.gameObject.tag == "MovingPlatform" && controller.isGrounded)
    {
      transform.parent = hit.transform;
    }

    if (controller.isGrounded)
    {
      anim.SetBool("isSliding", false);
    }

  }

}
