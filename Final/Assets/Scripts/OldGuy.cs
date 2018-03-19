using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldGuy : MonoBehaviour {

  public Animator animator;

  // Update is called once per frame
  void Update () {
    if (GameObject.Find("DialogueManager").GetComponent<AudioSource>().isPlaying)
    {
      animator.SetBool("IsTalking", true);
    } else
    {
      animator.SetBool("IsTalking", false);
    }
	}
}
