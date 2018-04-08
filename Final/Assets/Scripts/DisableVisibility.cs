using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVisibility : MonoBehaviour {

  public GameObject gameManager;

  // Update is called once per frame
  void Update()
  {

    if (gameManager.GetComponent<CameraSwitch>().cameraMode == 1)
    {
      if (gameManager.GetComponent<SkinnedMeshRenderer>() != null)
      {
        GetComponent<SkinnedMeshRenderer>().enabled = false;
        Debug.Log("changin");
      }

      if (gameManager.GetComponent<MeshRenderer>() != null)
      {
        GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("changin");
      }

    }

    if (gameManager.GetComponent<CameraSwitch>().cameraMode == 0)
    {

      if (gameManager.GetComponent<SkinnedMeshRenderer>() != null)
      {
        GetComponent<SkinnedMeshRenderer>().enabled = true;
      }

      if (gameManager.GetComponent<MeshRenderer>() != null)
      {
        GetComponent<MeshRenderer>().enabled = true;
      }

    }
  }
}
