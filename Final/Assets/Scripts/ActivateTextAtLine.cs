using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

  public string npcName;

  public TextAsset theText;

  public int startLine;
  public int endLine;

  public TextBoxManager theTextBox;

  public bool requireButtonPress;
  private bool waitForPress;

  public bool destroyWhenActivated;

  [Range(0f,10.0f)]
  public float lowPitchRange;

  [Range(0f, 10.0f)]
  public float highPitchRange;

  // Use this for initialization
  void Start () {
    theTextBox = FindObjectOfType<TextBoxManager>();
  }
	
	// Update is called once per frame
	void Update () {
		if(waitForPress && Input.GetButtonDown("Interact") && theTextBox.isActive == false)
    {
      theTextBox.ReloadScript(theText);
      theTextBox.currentLine = startLine;
      theTextBox.endAtLine = endLine;

      //*sets pitch of the voice based on given values
      theTextBox.lowPitchRange = lowPitchRange;
      theTextBox.highPitchRange = highPitchRange;

      //sets the NPC or talkable object name
      theTextBox.theName.text = npcName;

      theTextBox.EnableTextBox();

    }

	}

  private void OnTriggerEnter(Collider other)
  {
    if(other.name == "Player")
    {
      if (requireButtonPress)
      {
        waitForPress = true;
        return;
      }

      //sets pitch of the voice based on given values
      theTextBox.lowPitchRange = lowPitchRange;
      theTextBox.highPitchRange = highPitchRange;

      //sets the NPC or talkable object name
      theTextBox.theName.text = npcName;

      theTextBox.ReloadScript(theText);
      theTextBox.currentLine = startLine;
      theTextBox.endAtLine = endLine;
      theTextBox.EnableTextBox();

      if (destroyWhenActivated)
      {
        Destroy(gameObject);
      }

      waitForPress = false;

    }
  }

  private void OnTriggerExit(Collider other)
  {
    if(other.name == "Player")
    {
      waitForPress = false;
    }
  }

}
