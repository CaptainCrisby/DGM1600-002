using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public static int brickCount;

    void Awake()
    {
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

    //loadin' levels
    public void LoadLevel(string level)
    {
        brickCount = 0;
        SceneManager.LoadScene(level);
    }

    public void LoadNextLevel()
    {
        brickCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    


}
