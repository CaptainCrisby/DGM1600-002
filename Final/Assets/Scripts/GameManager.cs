using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public int currentGem;
  public Text gemText;

  public int currentHealth; //the health the player currently has
  public Sprite[] healthSprites; //The heart images 
  public Image img; //HUD Heart image

  //loading next levels
  public void LoadNextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  //Adding gem count in HUD***********************************************************
  public void AddGem(int gemToAdd)
  {
    GameObject.Find("GemUI").GetComponent<Animator>().SetBool("gemObtain", true);
    currentGem += gemToAdd;
    gemText.text = " : " + currentGem;

    //if gemObtain boolean is already activated, stop the current coroutine and start a new one
    if(GameObject.Find("GemUI").GetComponent<Animator>().GetBool("gemObtain"))
    {
      StopCoroutine(ExitTime());
      StartCoroutine(ExitTime());
    }

  }

  IEnumerator ExitTime()
  {
    yield return new WaitForSeconds(10.0f);
    GameObject.Find("GemUI").GetComponent<Animator>().SetBool("gemObtain", false);
  }



  //Updates health using a switch statement
  private void Update()
  {
    //Set current health to be the same as the Health Manager's, locates the Image UI renderer
    currentHealth = GetComponent<HealthManager>().currentHealth;

    switch (currentHealth)
    {
      case 0:
        img.sprite = healthSprites[0];
        break;
      case 1:
        img.sprite = healthSprites[1];
        break;
      case 2:
        img.sprite = healthSprites[2];
        break;
      case 3:
        img.sprite = healthSprites[3];
        break;
      case 4:
        img.sprite = healthSprites[4];
        break;
      case 5:
        img.sprite = healthSprites[5];
        break;
      case 6:
        img.sprite = healthSprites[6];
        break;
      case 7:
        img.sprite = healthSprites[7];
        break;
      case 8:
        img.sprite = healthSprites[8];
        break;
      default:
        img.sprite = healthSprites[0];
        break;
    }
  }

}
