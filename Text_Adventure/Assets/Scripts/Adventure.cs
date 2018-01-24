using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure : MonoBehaviour {

    public enum States { cell, window, gate, bed };
    public States currentState;
    //public Texture2D greenMan;


    // Use this for initialization
    void Start() {
        currentState = States.cell;
    }

    // Update is called once per frame
    void Update() {
        if (currentState == States.cell)
        {
            Cell();
        }

        else if (currentState == States.bed)
        {
            Bed();
        }

        else if (currentState == States.gate)
        {
            Gate();
        }

        else if ((currentState == States.window))
        {
            Window();
        }

    }

    // "\n" makes it so it displays on a new line. This is a bunch of stuff that runs depending on currentState's value.

    private void Cell(){
        //GUI.DrawTexture(new Rect(10, 10, 60, 60), greenMan, ScaleMode.ScaleToFit, true, 10.0F);
        print("Hello UVU number " + System.Environment.UserName + ". " +
            "You are in a cell. It's gross and dark and stinky. \n" +
            "There is a Window. \n" +
            "There is a Gate. \n" +
            "There is a Bed. \n" +
            "Press W for Window, G for gate, B for bed.");
        if (Input.GetKeyDown(KeyCode.W)) { currentState = States.window; }
        if (Input.GetKeyDown(KeyCode.G)) { currentState = States.gate; }
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
    }

    private void Bed()
    {
        print("You are in a bed. It's gross and dark and stinky. " +
            "Yoodoo. \n" +
            "Yodo. \n" +
            "You are now Frodo. \n" +
            "Press W for Window, G for gate, C for cell.");
        if (Input.GetKeyDown(KeyCode.W)) { currentState = States.window; }
        if (Input.GetKeyDown(KeyCode.G)) { currentState = States.gate; }
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
    }

    private void Gate()
    {
        print("You found a gate. It's gross and dark and stinky. " +
            "Yoodoo. \n" +
            "Yodo. \n" +
            "You are now Frodo. \n" +
            "Press C for Cell, W for window, B for bed.");
        if (Input.GetKeyDown(KeyCode.W)) { currentState = States.window; }
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
    }

    private void Window()
    {
        print("You found a Window. It's gross and dark and stinky. " +
            "Yoodoo. \n" +
            "Yodo. \n" +
            "You are now Frodo. \n" +
            "Press C for Cell, G for Gate, B for Bed.");
        if (Input.GetKeyDown(KeyCode.G)) { currentState = States.gate; }
        if (Input.GetKeyDown(KeyCode.B)) { currentState = States.bed; }
        if (Input.GetKeyDown(KeyCode.C)) { currentState = States.cell; }
    }

}
