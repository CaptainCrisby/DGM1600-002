using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour {

  public int healToGive = 1;
  public AudioSource source;
  public AudioClip heal;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      source.PlayOneShot(heal);

      FindObjectOfType<HealthManager>().HealPlayer(healToGive);
    }
  }

}
