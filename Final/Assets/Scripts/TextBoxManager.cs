using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
  public GameObject textBox;

  public Text theName;
  public Text theText;

  public TextAsset textFile;
  public string[] textLines;

  public int currentLine;
  public int endAtLine;

  public PlayerController player;

  public bool isActive;

  public bool stopPlayerMovement;

  private bool isTyping = false;
  private bool cancelTyping = false;
  public float typeSpeed;

  public AudioSource source;
  public float lowPitchRange;
  public float highPitchRange;

  //Animation stuff
  public Animator animator;

  public AudioClip[] letters; //AC TEXT STYLE
  public AudioClip[] letterSounds; //AC TEXT STYLE

  // Use this for initialization
  void Start()
  {
    player = FindObjectOfType<PlayerController>();

    letterSounds = letters; //AC TEXT STYLE

    if (textFile != null)
    {
      textLines = (textFile.text.Split('\n'));
    }
    
    if(endAtLine == 0)
    {
      endAtLine = textLines.Length - 1;
    }

    //If the textbox is active, enable, otherwise disable
    if (isActive)
    {
      EnableTextBox();
    }
    else
    {
      DisableTextBox();
    }
    //animation shtuff
    animator = GameObject.Find("Textbox").GetComponent<Animator>();
  }

  private void Update()
  {
    if (!isActive)
    {
      return;
    }

    //theText.text = textLines[currentLine];

    if (Input.GetButtonDown("Continue"))
    {
      if (!isTyping)
      {
        currentLine += 1;

        if (currentLine > endAtLine)
        {
          DisableTextBox();

        } else
        {
          StartCoroutine(TextScroll(textLines[currentLine]));
        }

      }

      else if(isTyping && !cancelTyping)
      {
        cancelTyping = true;
      }

    }

  }

  private IEnumerator TextScroll (string lineOfText)
  {
    int letter = 0;
    theText.text = "";
    isTyping = true;
    cancelTyping = false;
    while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
    {
      theText.text += lineOfText[letter];

      //AC TEXT
      source.pitch = Random.Range(lowPitchRange, highPitchRange);
      int audioID = GetLetterSound(lineOfText[letter].ToString()); //AC TEXT STYLE
      source.clip = (audioID <= 26) ? letterSounds[audioID] : letterSounds[0]; //AC TEXT STYLE
      source.Play();//AC TEXT STYLE

      //trying to get ` to make the game hesitate
      if (theText.text.Contains("`"))
      {
        //replace ` with ""
        lineOfText = lineOfText.Replace("`", ""); //this needs to be changing the individual character not the whole line of text
        yield return new WaitForSeconds(1);
        letter += 1;
      } else

      letter += 1;
      
      yield return new WaitForSeconds(typeSpeed);
    }
    theText.text = lineOfText;
    isTyping = false;
    cancelTyping = false;
  }

  public void EnableTextBox()
  {
    textBox.SetActive(true);
    isActive = true;
    animator.SetBool("isActive", true);

    if (stopPlayerMovement)
    {
      player.canMove = false;
    }

    StartCoroutine(TextScroll(textLines[currentLine]));

  }

  public void DisableTextBox()
  {
    textBox.SetActive(false);
    isActive = false;
    player.canMove = true;
  }

  public void ReloadScript(TextAsset theText)
  {
    if(theText != null)
    {
      textLines = new string[1];
      textLines = (theText.text.Split('\n'));
    }
  }

  //ANIMAL CROSSING STYLE SPEECH
  int GetLetterSound(string letter)
  {
    letter = letter.ToLower();

    switch (letter)
    {
      case ".": case " ": case "'": case "?": case "!": case "":
        return 26;
      case "a":
        return 0;
      case "b":
        return 1;
      case "c":
        return 2;
      case "d":
        return 3;
      case "e":
        return 4;
      case "f":
        return 5;
      case "g":
        return 6;
      case "h":
        return 7;
      case "i":
        return 8;
      case "j":
        return 9;
      case "k":
        return 10;
      case "l":
        return 11;
      case "m":
        return 12;
      case "n":
        return 13;
      case "o":
        return 14;
      case "p":
        return 15;
      case "q":
        return 16;
      case "r":
        return 17;
      case "s":
        return 18;
      case "t":
        return 19;
      case "u":
        return 20;
      case "v":
        return 21;
      case "w":
        return 22;
      case "x":
        return 23;
      case "y":
        return 24;
      case "z":
        return 25;
      default:
        return 26;
    }

  }



}

