using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

  public GameObject thirdPerson;
  public GameObject firstPerson;
  public int cameraMode;

  public GameObject player;
  public GameObject playerModel;
	
	// Update is called once per frame
	void Update () {
    if (player.GetComponent<CharacterController>().isGrounded == true && playerModel.GetComponent<Animator>().GetFloat("Speed") == 0)
    {
      if (Input.GetButtonDown("Camera"))
      {
        if (cameraMode == 1)
        {
          cameraMode = 0;
        }
        else
        {
          cameraMode += 1;
        }
        StartCoroutine(CameraChange());
      }
    }

	}


  IEnumerator CameraChange()
  {
    yield return new WaitForSeconds(0.01f);
    if(cameraMode == 0)
    {
      thirdPerson.SetActive(true);
      firstPerson.SetActive(false);
    }

    if(cameraMode == 1)
    {
      thirdPerson.SetActive(false);
      firstPerson.SetActive(true);
    }
  }


}
