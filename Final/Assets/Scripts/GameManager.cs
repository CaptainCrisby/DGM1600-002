using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public int currentGem;
  public Text gemText;
  public Text healthText;

  //loading next levels
  public void LoadNextLevel()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void AddGem(int gemToAdd)
  {
    currentGem += gemToAdd;
    gemText.text = "Gems: " + currentGem;
  }

}
