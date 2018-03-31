using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

  public AudioClip step;
  public AudioClip dab;
  public AudioSource source;

  private bool hasDabbed;
  private float lowPitchRange = .75F;
  private float highPitchRange = 1.5F;

  //function that is called during the walking animation event
  void Step()
  {
    source.pitch = Random.Range(lowPitchRange, highPitchRange);
    source.PlayOneShot(step);
  }

  //function that is called during dabbing animation event
  void Dab()
  {
    if (Input.GetButtonDown("Fire1") && hasDabbed == false)
    {
      source.pitch = Random.Range(lowPitchRange, highPitchRange);
      source.PlayOneShot(dab);
      hasDabbed = true;
    }
  }

  private void Update()
  {
    if (Input.GetButtonUp("Fire1"))
    {
      hasDabbed = false;
    }
  }

}
