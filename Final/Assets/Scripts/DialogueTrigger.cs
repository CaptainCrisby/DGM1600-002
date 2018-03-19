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
    //If the playabledirector isn't running and the trigger dialogue isn't already running...)
    if (GetComponent<PlayableDirector>().state != PlayState.Playing && isRunning == false)
    {
      //Trigger the dialogue, set isRunning to true so that it won't run over and over
      TriggerDialogue();
      isRunning = true;
    }
  }
}
