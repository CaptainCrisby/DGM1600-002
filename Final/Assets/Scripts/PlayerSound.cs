using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

  public AudioClip step;
  public AudioClip dab;
  public AudioClip flip;
  public AudioClip land;
  public AudioClip jump;
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

  void Flip()
  {
    source.pitch = Random.Range(lowPitchRange, highPitchRange);
    source.PlayOneShot(flip);
  }

  void Land()
  {
    source.pitch = Random.Range(lowPitchRange, highPitchRange);
    source.PlayOneShot(land);
  }

  void Jump()
  {
    source.pitch = Random.Range(lowPitchRange, highPitchRange);
    source.PlayOneShot(jump);
  }

  private void Update()
  {
    if (Input.GetButtonUp("Fire1"))
    {
      hasDabbed = false;
    }
  }

}
