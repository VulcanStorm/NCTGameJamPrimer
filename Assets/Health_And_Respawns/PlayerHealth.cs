using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public int currentHealth = 100;
	
	public Vector3 spawnPosition = Vector3.zero;
	
	public bool autoSetup = true;
	
	// Use this for initialization
	void Start () {
		
		// check if we need to auto setup
		if(autoSetup == true){
			spawnPosition = transform.position;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// check if health <= 0
		if(currentHealth <= 0){
			// player dead
			print ("player dead");
			// respawn the player
			RespawnPlayer ();
		}
		
	}
	
	
	public void RespawnPlayer () {
		
		// set our objects position to the spawn position
		transform.position = spawnPosition;
		
		// reset our health
		currentHealth = 100;
		
	}
	
	
	public void TakeDamage (int damage){
		
		// take damage away from health
		currentHealth = currentHealth - damage;
		
	}
	
	public void HealHealth (int healing){
		
		// add healing to current health
		currentHealth = currentHealth + healing;
		
	}
	
}












