﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {


	// Update is called once per frame
	void Update () {
        //get current paddle position
        Vector3 paddlePosition = new Vector3(0, gameObject.transform.position.y, 0);

        //audiosource.playclipatpoint (when colliding)

        //get horizontal position
        float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;

        paddlePosition.x = mousePositionInBlocks;

        //set this paddle object to the saved position
        gameObject.transform.position = paddlePosition;
	}
}