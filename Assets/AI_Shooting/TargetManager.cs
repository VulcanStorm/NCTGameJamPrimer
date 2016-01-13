using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour {
	
	public static TargetManager singleton;
	
	public bool autoSetup = true;
	public TankShoot[] targetArray = new TankShoot[5];
	
	
	// Use this for initialization
	void Start () {
		// assign the singleton reference
		singleton = this;
		
		// give all of the targets, the required IDs
		if(autoSetup == true){
			
			// iterate over all of the targets
			for(int i = 0; i < targetArray.Length; i++){
				// set their ID to the index in the array
				if(targetArray[i] != null){
					targetArray[i].myTargetID = i;
				}
			}
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RemoveTarget (int targetID){
		// nullify our target reference
		targetArray[targetID] = null;
		
	}
	
	
	
	
	
	
}
