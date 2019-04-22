using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour {

  public GameObject thePlayer;
  public float targetDistance;
  public float allowedDistance;
  public GameObject theNPC;
  public float followSpeed;
  public RaycastHit shot;
	
	// Update is called once per frame
	void Update () {
    transform.LookAt(thePlayer.transform);
    if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out shot))
    {
      targetDistance = shot.distance;
      if(targetDistance >= allowedDistance)
      {
        followSpeed = 0.00000000000000000002f;
        theNPC.GetComponent<Animator>().Play("walk");
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, followSpeed);

      }
      else
      {
        followSpeed = 0;
        theNPC.GetComponent<Animator>().Play("idle");
      }
    }
	}
}
