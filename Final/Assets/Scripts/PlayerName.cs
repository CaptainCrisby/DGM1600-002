using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour {

  public string playerName;

  //setting the player name
  public void SetPlayerName()
  {
    playerName = GameObject.Find("Name").GetComponent<InputField>().text;
    //Don't destroy it when loading future scenes. We need this later!
    DontDestroyOnLoad(this.gameObject);

    if (playerName == null)
    {
      playerName = "Payton";
    }
  }
}
