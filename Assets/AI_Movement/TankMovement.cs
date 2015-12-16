using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour {
	
	public Vector3 relativeTargetPos = Vector3.zero;
	public Vector3 targetPos = Vector3.zero;
	public int moveSpeed = 3;
	public int turnSpeed = 60;
	
	public float minDistToStop = 2;
	
	public float minTurnDist = -2;
	public float maxTurnDist = 2;
	
	private Transform thisTransform = null;
	
	// Use this for initialization
	void Start () {
		thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate () {
		
		// calculate the relative target position
		relativeTargetPos = thisTransform.InverseTransformPoint(targetPos);
	
		// check if target is left
		if(relativeTargetPos.x < minTurnDist){
			// turn left
			thisTransform.Rotate (Vector3.up * turnSpeed * -1 * Time.deltaTime);
		}
		// check if target it right
		else if(relativeTargetPos.x > maxTurnDist){
			// turn right
			thisTransform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
		}
		// target isnt left or right of us...
		else if(relativeTargetPos.z > minDistToStop){
			// walk forward
			thisTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		// target is behind us?
		else if(relativeTargetPos.z < 0){
			// turn right :D
			thisTransform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
		}
		
	}
}





