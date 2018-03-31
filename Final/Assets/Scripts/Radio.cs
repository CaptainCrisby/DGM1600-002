using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

  public GameObject player;
  public new Animation animation; //think about renaming this
  public Animator anim;

  public AudioClip[] music;
  public AudioClip bang;
  public AudioSource source;

  public bool alreadyDabbed;

  void Start()
  {
    source.clip = music[Random.Range(0, music.Length)];
    source.Play();
    anim.SetBool("hit", false); //probably unnecessary, look more into it later.
    alreadyDabbed = false;
  }


  //If the player is close and is dabbing
  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      PlayOnce();
      Debug.Log("You're in my space");


      if (alreadyDabbed == false)
      {
        anim.SetBool("hit", false);
      }


      if (alreadyDabbed == false && Input.GetButtonDown("Fire1"))
      {
        anim.SetBool("hit", true);

        //Play a new song
        PlayNewSong();
      }
    }
  }

  //Plays a new song
  void PlayNewSong()
  {
    source.PlayOneShot(bang);

    source.clip = music[Random.Range(0, music.Length)];
    source.Play();
    alreadyDabbed = true;
  }

  void PlayOnce()
  {
    if (Input.GetButtonUp("Fire1") || !player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("MC_Dab"))
    {
      alreadyDabbed = false;
    }
    else if (Input.GetButtonDown("Fire1"))
    {
      alreadyDabbed = true;
    }
  }



}
