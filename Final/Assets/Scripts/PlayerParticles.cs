using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {

  public GameObject puffEffect;
  public GameObject sweatEffect;

  private void GenerateSmoke()
  {
    Instantiate(puffEffect, transform.position, transform.rotation);
  }

  private void GenerateSweat()
  {
    GameObject sweat = Instantiate(sweatEffect, transform.position, transform.rotation) as GameObject; //Setting this as an object
    sweat.transform.parent = GameObject.Find("Player").transform; //making the sweat follow the player
  }
}
