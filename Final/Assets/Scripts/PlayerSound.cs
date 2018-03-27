using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

  public AudioClip step;
  public AudioSource source;

  private float lowPitchRange = .75F;
  private float highPitchRange = 1.5F;

  //function that is called during the walking animation event
  void Step()
  {
    source.pitch = Random.Range(lowPitchRange, highPitchRange);
    source.PlayOneShot(step);
  }

}
