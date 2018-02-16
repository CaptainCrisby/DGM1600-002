using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public AudioClip bounce;
    public AudioClip bounce2;
    public GameObject Paddle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if it's colliding with an object named "paddle"
        if(collision.gameObject.name == "Paddle")
        {
            AudioSource.PlayClipAtPoint(bounce2, new Vector3(0, 0, 0));
        }
        else //otherwise just don't mess with the pitch
        {
            AudioSource.PlayClipAtPoint(bounce, new Vector3(0, 0, 0));
        }

        //AudioSource.PlayClipAtPoint(bounce, new Vector3(0,0,0));
    }

}