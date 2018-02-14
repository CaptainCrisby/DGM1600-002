using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public AudioClip bounce;
    AudioSource audioSource;
    public GameObject Paddle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if it's colliding with an object named "paddle"
        if(collision.gameObject == Paddle)
        {
            audioSource.pitch = -55;
            AudioSource.PlayClipAtPoint(bounce, new Vector3(0, 0, 0));
        }
        else //otherwise just don't mess with the pitch
        {
            audioSource.pitch = 0;
            AudioSource.PlayClipAtPoint(bounce, new Vector3(0, 0, 0));
        }

        //AudioSource.PlayClipAtPoint(bounce, new Vector3(0,0,0));
    }

}