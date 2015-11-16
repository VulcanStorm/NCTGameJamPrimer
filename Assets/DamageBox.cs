using UnityEngine;
using System.Collections;

public class DamageBox : MonoBehaviour {
	
	public int damage = 20;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision col){
		
		// check if we have collided with the player
		if(col.collider.tag == "Player"){
			
			print ("player collided");
			// send the player a message saying it took damage
			col.transform.SendMessage("TakeDamage",damage);
			// destroy this box
			Destroy (this.gameObject);
		}
		
	}
}











