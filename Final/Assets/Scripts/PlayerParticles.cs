using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {

  public GameObject puffEffect;

  private void GenerateSmoke()
  {
    Instantiate(puffEffect, transform.position, transform.rotation);
  }
}
