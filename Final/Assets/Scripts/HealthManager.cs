using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

  public int maxHealth;
  public int currentHealth;

  public PlayerController thePlayer;

  public float invincibilityLength;
  private float invincibilityCounter;

  public Renderer playerRenderer;
  private float flashCounter;
  public float flashLength = 0.1f;

  private bool isRespawning;
  private Vector3 respawnPoint;
  public float respawnLength;

  public Text healthText;

	// Use this for initialization
	void Start () {
    currentHealth = maxHealth;

    respawnPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(invincibilityCounter > 0)
    {
      invincibilityCounter -= Time.deltaTime;

      flashCounter -= Time.deltaTime;
      if(flashCounter <= 0)
      {
        playerRenderer.enabled = !playerRenderer.enabled;
        flashCounter = flashLength;
      }

      if(invincibilityCounter <= 0)
      {
        playerRenderer.enabled = true;
      }
    }

    healthText.text = "Current Health: " + currentHealth;

  }

  public void HurtPlayer(int damage, Vector3 direction)
  {
    if (invincibilityCounter <= 0)
    {
      currentHealth -= damage;

      if (currentHealth <= 0)
      {
        Respawn();
      }
      else
      {

        thePlayer.Knockback(direction);

        invincibilityCounter = invincibilityLength;

        playerRenderer.enabled = false;

        flashCounter = flashLength;
      }
    }
  }

  public void Respawn()
  {
    //thePlayer.transform.position = respawnPoint;
    //currentHealth = maxHealth;
    if (!isRespawning)
    {
      StartCoroutine("RespawnCo");
    }
  }

  public IEnumerator RespawnCo()
  {
    isRespawning = true;
    thePlayer.gameObject.SetActive(false);

    yield return new WaitForSeconds(respawnLength);
    isRespawning = false;

    thePlayer.gameObject.SetActive(true);
    thePlayer.transform.position = respawnPoint;
    currentHealth = maxHealth;

    invincibilityCounter = invincibilityLength;
    playerRenderer.enabled = false;
    flashCounter = flashLength;
  }

  public void HealPlayer(int healAmount)
  {
    currentHealth += healAmount;

    if(currentHealth > maxHealth)
    {
      currentHealth = maxHealth;
    }
  }

}
