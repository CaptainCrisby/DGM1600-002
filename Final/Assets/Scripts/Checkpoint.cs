using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

  public HealthManager theHealthMan;

  public Renderer rend;

  public Material cpOff;
  public Material cpOn;

	// Use this for initialization
	void Start ()
  {
    theHealthMan = FindObjectOfType<HealthManager>();
	}

  public void CheckpointOn()
  {
    Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
    foreach (Checkpoint cp in checkpoints)
    {
      cp.CheckpointOff();
    }

    rend.material = cpOn;
  }

  public void CheckpointOff()
  {
    rend.material = cpOff;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag.Equals("Player"))
    {
      theHealthMan.SetSpawnPoint(transform.position);
      CheckpointOn();
    }
  }
}
