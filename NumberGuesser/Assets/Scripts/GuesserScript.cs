using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuesserScript : MonoBehaviour {

    public int max;
    public int min;
    private int guess;
    public int count;

    // Use this for initialization
    private void Start () {

        print("Welcome to Number Guesser");

        print("Pick a number between " + min + " and " + max);

        //Is the value GUESS
        NextGuess();
        //Instructions - Push these buttons
        print("Up arrow for higher, down arrow for lower, enter for correct.");

        max = max + 1;
	}

    private void NextGuess()
    {
        count--;
        guess = Random.Range(min, max);
        //prior guess code: guess = (min + max) / 2;********
        print("Is the number " + guess + "?");
    }
	
	// Update is called once per frame
	 void Update () {
        //Up arrow
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }

        //Down Arrow
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }

        //Enter button
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            //checks if the number is 666
            if (guess == 666)
            {
                guess = 777;
                print("you did this to me :(");
                print("I'm changing your answer to 777 because you are mean :(((");
                print("Your number is now " + guess + ".");
                print("punk.");
            }
            else
            print("i'm very smurt :O");
        }

        //count check (checks if it's zero, and if so, player wins
        if (count <= 0)
            {
            print("... I guess you won...");
            }
    }
}