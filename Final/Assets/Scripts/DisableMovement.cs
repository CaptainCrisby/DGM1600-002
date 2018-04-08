using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour {

  public GameObject gameManager;
	
	// Update is called once per frame
	void Update () {
		if(gameManager.GetComponent<CameraSwitch>().cameraMode == 1)
    {
      GetComponent<PlayerController>().enabled = false;
      GetComponent<CharacterController>().enabled = false;
    }

    if (gameManager.GetComponent<CameraSwitch>().cameraMode == 0)
    {
      GetComponent<PlayerController>().enabled = true;
      GetComponent<CharacterController>().enabled = true;
    }
	}
}
