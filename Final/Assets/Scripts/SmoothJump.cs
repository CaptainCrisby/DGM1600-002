using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothJump : MonoBehaviour {
  public float fallMultiplier = 2.5f;
  public float lowJumpMultiplier = 2f;

  public GameObject player;
  private float jumpForce;

  private void Awake()
  {
    jumpForce = GameObject.Find("Player").GetComponent<PlayerController>().jumpForce;
  }

  private void FixedUpdate()
  {
    if (jumpForce < 0)
    {
      jumpForce += Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    } else if (jumpForce > 0 && !Input.GetButtonDown("Jump"))
    {
      jumpForce += Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;
    }
  }
}
