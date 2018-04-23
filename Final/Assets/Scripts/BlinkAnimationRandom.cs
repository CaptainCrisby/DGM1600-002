using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAnimationRandom : MonoBehaviour {

  //   Random eye blinker script 
  public float blinkEyeRate;
  private Animator anim;
  private float previousBlinkEyeRate;
  private float blinkEyeTime;

  void Update()
  {
    anim = gameObject.GetComponent<Animator>();
    if (Time.time > blinkEyeTime)
    {
      previousBlinkEyeRate = blinkEyeRate;
      blinkEyeTime = Time.time + blinkEyeRate;
      //trigger          
      anim.SetTrigger("blink");
      while (previousBlinkEyeRate == blinkEyeRate)
      {
        // Random Rate from 4 secs to 10secs
        blinkEyeRate = Random.Range(4f, 10f);
      }
    }


  }
}
