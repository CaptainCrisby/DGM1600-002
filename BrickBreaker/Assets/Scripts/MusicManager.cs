using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager instance = null;

    // Use this for initialization
    void Awake () {
        //Check if instance already exists - Singleton
        if (instance == null)       //If the instance doesn't have anything assigned.
        {
            instance = this;        //Set the instance.
        }
        //If it already exists destroy it
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //Don't destroy it when loading, though.
        DontDestroyOnLoad(this.gameObject);

    }
	
}
