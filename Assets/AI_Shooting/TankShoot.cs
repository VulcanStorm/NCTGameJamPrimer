using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankShoot : MonoBehaviour {
	
	public List<int> targets = new List<int>();
	
	public Transform firePoint;
	public GameObject projectile;
	
	public TankTurret tankTurret = null;
	
	public LayerMask rayHitLayers;
	
	public int myTargetID = -1;
	
	public bool hasTarget = false;
	public Transform currentTargetTransform;
	public int currentTargetID = -1;
	public Transform thisTransform;
	
	public bool isAimedAtTarget = false;
	public float timer = 0;
	public float fireTime = 0.33f;
	
	public float health = 100;
	
	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		// get a target
		GetNewTarget ();
		// aim at the target
		AimAtTarget();
		// shoot at target
		ShootAtTarget();
		
	}
	
	public void AddNewTarget (int id) {
		targets.Add(id);
	}
	
	public void RemoveTarget (int id) {
		targets.Remove(id);
	}
	
	public void TakeDamage (float dmg){
		health -= dmg;
		// check for death
		if(health <=0){
			KillSelf();
		}
	}
	
	void KillSelf () {
		TargetManager.singleton.RemoveTarget(myTargetID);
		Destroy (this.gameObject);
	}
	
	void GetNewTarget () {
		
		// check if we already have a target
		if(hasTarget == false){
			// iterate over all of our possible targets
			for(int i=0; i<targets.Count;i++){
				
				// check sight to target
				
				// get the target id
				int targetID = targets[i];
				
				// check for no target with this ID
				if(TargetManager.singleton.targetArray[targetID] == null){
					// remove this from our target list
					targets.RemoveAt(i);
					// decrease i by 1, to move back and check the new index 3
					i = i-1;
				}
				else{
					
					// get a reference to the target transform
					currentTargetTransform = TargetManager.singleton.targetArray[targetID].thisTransform;
							
					// create a raycast hit info
					RaycastHit hitInfo = new RaycastHit();
					
					// do the linecast to check for vision
					Physics.Linecast(thisTransform.position, currentTargetTransform.position, out hitInfo, rayHitLayers);
					
					// check if we hit anything
					if(hitInfo.collider == null){
						// we didnt hit anything
					// we can shoot at this target :D
						hasTarget = true;
						// store the current target id
						currentTargetID = targetID;
			
						// stop the loop
						break;
					}
					else{
						//Debug.Log ("HIT SOMETHING!, "+hitInfo.transform.root.name);
					}
				}
			}
		}
		// we must have a target then...
		else{
			// check if we can still shoot this target
			if(TargetManager.singleton.targetArray[currentTargetID] == null){
				// remove this from our target list
				targets.Remove(currentTargetID);
				currentTargetTransform = null;
				currentTargetID = -1;
				hasTarget = false;
			}
			else{
				
				// get a reference to the target transform
				currentTargetTransform = TargetManager.singleton.targetArray[currentTargetID].thisTransform;
				
				// create a raycast hit info
				RaycastHit hitInfo = new RaycastHit();
				
				// do the linecast to check for vision
				Physics.Linecast(thisTransform.position, currentTargetTransform.position, out hitInfo, rayHitLayers);
				
				// check if we hit anything
				if(hitInfo.collider != null){
					// we didnt hit anything
					// we can shoot at this target :D
					hasTarget = false;
				}
			}
		}
	}
	
	void AimAtTarget () {
		if(tankTurret != null){
			tankTurret.doAim = hasTarget;
		}
	}
	
	void ShootAtTarget () {
		timer += Time.deltaTime;
		
		if(timer >= fireTime){
			FireBullet();
		}
	}
	
	void FireBullet () {
		if(isAimedAtTarget == true){
			Instantiate(projectile,firePoint.position,firePoint.rotation);
			timer = 0;
		}
	}
	
	void AddTarget (int targetID){
		// add the target to the target list
		targets.Add (targetID);
	}
}
