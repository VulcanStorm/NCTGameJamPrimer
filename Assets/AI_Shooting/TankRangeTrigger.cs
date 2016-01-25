using UnityEngine;
using System.Collections;

public class TankRangeTrigger : MonoBehaviour {
	
	public TankShoot tankScript;
	
	void Start (){
		tankScript = GetComponentInParent<TankShoot>();
	}
	
	void OnTriggerEnter (Collider other){
		if(other.tag == "TankTrigger"){
			TankRangeTrigger otherScript = other.GetComponent<TankRangeTrigger>();
			tankScript.AddNewTarget(otherScript.tankScript.myTargetID);
		}
	}
	
	void OnTriggerExit (Collider other){
		if(other.tag == "TankTrigger"){
			TankRangeTrigger otherScript = other.GetComponent<TankRangeTrigger>();
			tankScript.RemoveTarget(otherScript.tankScript.myTargetID);
		}
	}
}
