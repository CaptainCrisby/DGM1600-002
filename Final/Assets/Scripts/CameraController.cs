using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public Transform target;
  public Transform pivot;
  public float maxViewAngle;
  public float minViewAngle;
  public float xSpeed = 20.0f;
  public float ySpeed = 20.0f;
  public float yMinLimit = -1;
  public float yMaxLimit = 90f;
  float smoothTime = 15f;
  float rotationYAxis = 0.0f;
  float rotationXAxis = 0.0f;
  float velocityX = 0.0f;
  float velocityY = 0.0f;

  private void Start()
  {
    Vector3 angles = transform.eulerAngles;
    rotationYAxis = angles.y;
    rotationXAxis = angles.x;

    //Controller doesn't changed rotation
    if (GetComponent<Rigidbody>())
    {
      GetComponent<Rigidbody>().freezeRotation = true;
    }

    Cursor.lockState = CursorLockMode.Locked;
  }

  private void LateUpdate()
  {
    if (target)
    {
      velocityX += xSpeed * Input.GetAxis("Mouse X") * 2f * 0.02f;
      velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;

      rotationYAxis += velocityX;
      rotationXAxis -= velocityY;
      rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
      Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
      Quaternion rotation = toRotation;

      transform.rotation = rotation;
      velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
      velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
      float desiredYAngle = pivot.eulerAngles.y;

      if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
      {
        pivot.rotation = Quaternion.Euler(maxViewAngle, desiredYAngle, 0);
      }
      if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
      {
        pivot.rotation = Quaternion.Euler(360f + minViewAngle, desiredYAngle, 0);
      }

    }
  }

  public static float ClampAngle(float angle, float min, float max)
  {
    if (angle < -360F)
    {
      angle += 360F;
    }
    if (angle > 360F)
    {
      angle -= 360F;
    }

    return Mathf.Clamp(angle, min, max);
  }

}
