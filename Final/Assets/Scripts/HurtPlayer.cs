using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

  public int damageToGive = 1;
  public AudioSource source;
  public AudioClip ow;

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "Player")
    {
      source.PlayOneShot(ow);
      Vector3 hitDirection = other.transform.position - transform.position;
      hitDirection = hitDirection.normalized;

      FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
    }
  }

}
