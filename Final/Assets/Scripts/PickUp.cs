using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

  public Camera playerCamera; 

  public GameObject item;
  public GameObject grabParent;

  Vector3 objectPos;

  public bool isHolding = false;
  public bool waitForPress;

  // Use this for initialization
  void Start () {
    playerCamera = FindObjectOfType<Camera>();
  }
	
	// Update is called once per frame
	void Update () {
    if(waitForPress && Input.GetKeyDown(KeyCode.Mouse0)) //if they had entered the object and pressed mouse...
    {
      isHolding = true; 
      item.GetComponent<Rigidbody>().useGravity = false;
      item.transform.SetParent(grabParent.transform); //set parent to grabParent yeet
      item.transform.position = grabParent.transform.position;
    } else if(isHolding && Input.GetKeyDown(KeyCode.Mouse0))
    {
      transform.parent = null; //Deparent object and revert it back
      item.GetComponent<Rigidbody>().useGravity = true;
      isHolding = false;
    }

	}

  //player enters, if they press mouse then "bam"!
  private void OnTriggerEnter(Collider other)
  {
    if (other.name == "Player")
    {
      waitForPress = true;
      return;
    }
  }
}
