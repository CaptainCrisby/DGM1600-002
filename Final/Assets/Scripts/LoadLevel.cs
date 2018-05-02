using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

  public string level;

  public void Level(string level)
  {
    SceneManager.LoadScene(level);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      StartCoroutine(ChangeLevel());
    }
  }

  IEnumerator ChangeLevel()
  {
    //fade out and load next level
    float fadeTime = GameObject.Find("Fading").GetComponent<Fading>().BeginFade(1);
    yield return new WaitForSeconds(fadeTime);
    Level(level);
  }

}
