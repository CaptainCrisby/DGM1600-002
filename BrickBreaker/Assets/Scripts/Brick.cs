using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int health;
    public Sprite[] sprites;

    private void Awake()
    {
        GameManager.brickCount++;
        print(GameManager.brickCount);
        //array testing by setting bricks to a cracked version
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        GetComponent<SpriteRenderer>().sprite = sprites[health];
        //if our heatlh gets to 0, then destroy it
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.brickCount--;
            print(GameManager.brickCount);
            if (GameManager.brickCount == 0)
            {
                FindObjectOfType<GameManager>().LoadNextLevel();
            }
        }
    }

}