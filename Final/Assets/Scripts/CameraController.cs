using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  //public float moveSpeed;

  public Transform target;

  public Vector3 offset;

  public bool useOffsetValues;

  public float rotateSpeed;

  public Transform pivot;

  public float maxViewAngle;
  public float minViewAngle;

  public bool invertY;

	// Use this for initialization
	void Start () {
    if (!useOffsetValues)
    {
      offset = target.position - transform.position;
    }

    pivot.transform.position = target.transform.position;
    pivot.transform.parent = null;

    //hide the cursor
    Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void LateUpdate () {

    pivot.transform.position = target.transform.position;

    //Get the x position of mouse and rotate the target :)
    float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
    pivot.Rotate(0, horizontal, 0);

    //Get the y position of the mouse and rotate the pivot :D
    float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

    if (invertY)
    {
      pivot.Rotate(vertical, 0, 0);
    } else
    {
      pivot.Rotate(-vertical, 0, 0);
    }

    //Limit up/down camera rotation
    float desiredYAngle = pivot.eulerAngles.y;
    float desiredXAngle = pivot.eulerAngles.x;

    if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
    {
      pivot.rotation = Quaternion.Euler(maxViewAngle, desiredYAngle, 0);
    }
    if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
    {
      pivot.rotation = Quaternion.Euler(360f + minViewAngle, desiredYAngle, 0);
    }


    //Move the camera based on the current rotation of the target and the original offset
    Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
    transform.position = target.position - (rotation * offset);
    
    transform.LookAt(target);

    if(transform.position.y < target.position.y)
    {
      transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
    }

  }
}
