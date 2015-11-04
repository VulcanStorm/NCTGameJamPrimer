using UnityEngine;
using System.Collections;

public class TriggerCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		
		print ("!!!OBJECT ENTERED TRIGGER!!!");
		
	}
	
	void OnTriggerStay (Collider other) {
		
		print ("!!!OBJECT WITHIN TRIGGER!!!");
		
	}
	
	void OnTriggerExit (Collider other) {
		
		print ("!!!OBJECT EXITED TRIGGER!!!");
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
