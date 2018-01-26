using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuesserScript : MonoBehaviour {

    public int max;
    public int min;
    private int guess;
    public int count;
    private int countSave;
    private int maxSave;
    private int minSave;

    // Use this for initialization
    private void Start () {

        print("Welcome to Number Guesser" +
            "\nPress E for EZ mode, M for Medium mode, H for HARD mode" +
            "Press C for the count.");

        print("Pick a number between " + min + " and " + max);
        Count();

        //Is the value GUESS
        NextGuess();
        //Instructions - Push these buttons
        print("Up arrow for higher, down arrow for lower, enter for correct, and R to restart.");

        //When resetting, ensures that that max won't go above 1001
        if (max < 1001)
        {
            max = max + 1;
        }
        countSave = count;
        maxSave = max;
        minSave = min;
    }


    //Guess the next number.
    private void NextGuess()
    {
        count--;
        //this ensures that it doesn't make a guess after var 'count' hits zero turns
        if (count > 0)
        {
            guess = Random.Range(min, max);
            //******prior guess code: guess = (min + max) / 2;********
            print("Is the number " + guess + "?");
        }
    }

    //Show the Count
    private void Count()
    {
        //I tried using (count > 1 && count < 1) but for some reason it's avoiding it? I additionally tried (count >= 2 && count <= 0) and that doesn't work either. 🤷
        //So I made them separate. Sorry!
        if (count > 1)
        {
            print("I have " + count + " guesses left.");
        }
        else if (count < 1)
        {
            print("I have " + count + " guesses left.");
        }
        else if (count == 1)
        {
            print("I have " + count + " guess left.");
        }
    }


    //Reset
    private void Reset()
    {
        max = maxSave;
        min = minSave;
        Start();
    }

    //HOLDUP (Let's the game pause for 3 seconds before resetting)
    IEnumerator Hold()
    {
        yield return new WaitForSecondsRealtime(3);
        Reset();
    }


    // Update is called once per frame
    void Update () {

        //SELECT MODE (EZ, MED, HARD)
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("I'm now restarting the game to easy mode.");
            count = 5;
            Reset();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            print("I'm now restarting the game to medium mode.");
            count = 10;
            Reset();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            print("I'm now restarting the game to hard mode.");
            count = 15;
            Reset();
        }

        //Allows player to check the number of turns the computer has
        if (Input.GetKeyDown(KeyCode.C))
        {
            Count();
        }

        //count check (checks if it's zero, and if so, player wins
        else if (count == 0)
        {
            //(switching the value to -1 so it doesn't pop up with the message a million times)
            count = -1;
            print("... I guess you won...");
            count = (countSave + 1);
            StartCoroutine(Hold());
        }

        //Pressing R to restart
        else if (Input.GetKeyDown(KeyCode.R))
        {
            print("I'm now restarting the game.");
            count = (countSave + 1);
            Reset();
        }

        //Up arrow
        else if (Input.GetKeyDown(KeyCode.UpArrow))
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
            count = (countSave + 1);
            StartCoroutine(Hold());
        }
    }
}