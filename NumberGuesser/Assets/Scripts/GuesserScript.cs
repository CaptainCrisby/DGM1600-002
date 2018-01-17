using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuesserScript : MonoBehaviour {

    public int max;
    public int min;
    public int guess;

    // Use this for initialization
    private void Start () {

        print("Welcome to Number Guesser");

        print("Pick a number between " + min + " and " + max);

        //Is the value GUESS
        print("Is the number " + guess + "?");
        //Instructions - Push these buttons
        print("Up arrow for higher, down arrow for lower, enter for correct.");


	}
	
	// Update is called once per frame
	 void Update () {
        //Up arrow
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            min = guess;
            guess = (min + max) / 2;
            print("Is the number " + guess + "?");
        }

        //Down Arrow
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            max = guess;
            guess = (min + max) / 2;
            print("Is the number " + guess + "?");
        }
        //Enter button
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) {
            print("i'm very smurt :O");
            }
    }
}