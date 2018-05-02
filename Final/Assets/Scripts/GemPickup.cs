using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickup : MonoBehaviour {

  public int value;

  public GameObject pickupEffect;

  public AudioSource source;
  public AudioClip gemSound;
  private float lowPitchRange = .75F;
  private float highPitchRange = 1.5F;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnTriggerEnter(Collider other)
  {
    if(other.tag == "Player")
    {
      source.pitch = Random.Range(lowPitchRange, highPitchRange);
      source.PlayOneShot(gemSound);

      FindObjectOfType<GameManager>().AddGem(value);

      Instantiate(pickupEffect, transform.position, transform.rotation);

      Destroy(gameObject);
    }
  }
}
