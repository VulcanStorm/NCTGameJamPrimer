using UnityEngine;
using System.Collections;

public class TankTurret : MonoBehaviour {
	
	public TankShoot tankScript = null;
	
	public Transform targetTransform = null;
	public Transform turret = null;
	public Transform barrel = null;
	
	public bool onTarget = false;
	public bool doAim = false;
	
	public Vector3 localTurretTargetPos;
	public float turretAngleToTarget;
	public float minTurretAcc = -2;
	public float maxTurretAcc = 2;
	public float turretRotSpeed = 60;
	
	public Vector3 localBarrelTargetPos;
	public float barrelAngleToTarget;
	public float minBarrelAcc = -2;
	public float maxBarrelAcc = 2;
	public float barrelRotSpeed = 30;
	
	public int aimCount;
	
	// Use this for initialization
	void Start () {
	
	}
	
	void OnDrawGizmos () {
		if(turret != null){
			Gizmos.DrawCube(turret.TransformPoint(localTurretTargetPos), Vector3.one);
			Gizmos.color = Color.red;
			Gizmos.DrawRay(barrel.position,barrel.forward * 50);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// we want to aim at the target
		if(doAim == true){
			
			// aim the turret
			targetTransform = tankScript.currentTargetTransform;
			
			// localise the target position
			localTurretTargetPos = turret.InverseTransformPoint(targetTransform.position);
			localBarrelTargetPos = barrel.InverseTransformPoint(targetTransform.position);
			// set the y to zero
			localTurretTargetPos.y = 0;
			
			// calculate the angle between turret forward, and our target
			turretAngleToTarget = Vector3.Angle(turret.forward, localTurretTargetPos);
			
			// set the aim count
			aimCount = -2;
			
			// check left
			if(localTurretTargetPos.x < minTurretAcc){
				// rotate turret left
				turret.Rotate (Vector3.up * turretRotSpeed * -1 * Time.deltaTime, Space.Self);
			}
			// check right
			else if(localTurretTargetPos.x > maxTurretAcc){
				// rotate turret right
				turret.Rotate (Vector3.up * turretRotSpeed * Time.deltaTime, Space.Self);
			}
			// check behind
			else if(localTurretTargetPos.z < 0){
				// turn right
				turret.Rotate (Vector3.up * turretRotSpeed * Time.deltaTime, Space.Self);
			}
			else{
				aimCount +=1;
			}
			
			
			
			// BARREL
			// check left
			if(localBarrelTargetPos.y < minBarrelAcc){
				// rotate barrel left
				barrel.Rotate (Vector3.right * barrelRotSpeed * Time.deltaTime, Space.Self);
			}
			// check right
			else if(localBarrelTargetPos.y > maxBarrelAcc){
				// rotate barrel right
				barrel.Rotate (Vector3.right * barrelRotSpeed * -1 * Time.deltaTime, Space.Self);
			}
			// check behind
			else{
				aimCount +=1;
			}
			
			// check if we're on target
			if(aimCount == 0){
				onTarget = true;
			}
			else{
				onTarget = false;
			}
			
			
		}
		else{
			onTarget = false;
		}
		
		// set whether we're on target to the tank shooting
		tankScript.isAimedAtTarget = onTarget;
		
	}
}
