using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTrigger : MonoBehaviour {

  public bool isRunning;
  public Dialogue dialogue;

  public void TriggerDialogue()
  {
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
  }
  private void Update()
  {
    //If the playabledirector exists and isn't running and the trigger dialogue isn't already running...)
    if (GetComponent<PlayableDirector>() != null && GetComponent<PlayableDirector>().state != PlayState.Playing && isRunning == false)
    {
      //Trigger the dialogue, set isRunning to true so that it won't run over and over
      TriggerDialogue();
      isRunning = true;
      //otherwise, if the playable director doesn't exist and it's not already running...
    } else if (isRunning == false && GetComponent<PlayableDirector>() == null)
    {
      //play it!
      isRunning = true;
      TriggerDialogue();
    }
  }
}
