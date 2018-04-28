using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

  public Text nameText;
  public Text dialogueText;
  public Animator animator;

  //yourname testing
  public string yourName;

  //audio information variables
  public AudioClip talk;
  private AudioSource source;
  private float lowPitchRange = .75F;
  private float highPitchRange = 1.5F;

  //For getting SceneName and checking
  private string sceneName;
  private Scene currentScene;

  public Queue<string> sentences;

	// Use this for initialization
	void Start () {
    //this nabs the current scene's name
    currentScene = SceneManager.GetActiveScene();
    sceneName = currentScene.name;

    sentences = new Queue<string>();
    source = GetComponent<AudioSource>();   /////////////////////////////

    //Get your name
    if (yourName != null)
    {
      yourName = GameObject.Find("NameManager").GetComponent<PlayerName>().playerName;
    }

  }


  public void StartDialogue (Dialogue dialogue)
  {

      animator.SetBool("IsOpen", true);

      nameText.text = dialogue.name;

      sentences.Clear();

      foreach (string sentence in dialogue.sentences)
      {
        sentences.Enqueue(sentence);
      }
      DisplayNextSentence();

  }


  public void DisplayNextSentence()
  {
    if (sentences.Count == 0)
    {
      EndDialogue();
      return;
    }
    string sentence = sentences.Dequeue();

    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
  }

  IEnumerator TypeSentence (string sentence)
  {

    //check if I wrote the phrase "Playername" and replace it with the real name
    if (sentence.Contains("playerName"))
    {
      sentence = sentence.Replace("playerName", yourName);
    }

    dialogueText.text = "";
    foreach (char letter in sentence.ToCharArray())
    {
      source.pitch = Random.Range(lowPitchRange, highPitchRange);
      source.PlayOneShot(talk);
      dialogueText.text += letter;
      yield return new WaitForSeconds(0.05f);
    }
  }


  void EndDialogue()
  {
    animator.SetBool("IsOpen", false);

    if (sceneName == "Level00")
    {
      SceneManager.LoadScene("Level00_Name");
    }

    if (sceneName == "Level00_NameCheck")
    {
      SceneManager.LoadScene("Level02");
    }
  }
}
