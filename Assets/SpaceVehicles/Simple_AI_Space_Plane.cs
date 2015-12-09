using UnityEngine;
using System.Collections;

public class Simple_AI_Space_Plane : Simple_Space_Plane {

	int targetPitch = 0;
	int targetRoll = 0;
	int targetYaw = 0;

	float pitchWaitTime = 0f;
	float rollWaitTime = 0f;
	float yawWaitTime = 0f;

	float pitchTimer = 0f;
	float rollTimer = 0f;
	float yawTimer = 0f;

	public override void GetInput () {
		pitchTimer += Time.deltaTime;
		rollTimer += Time.deltaTime;
		yawTimer += Time.deltaTime;

		if (pitchTimer > pitchWaitTime) {
			pitchTimer = 0;
			pitchWaitTime = Random.Range(1,3);
			targetPitch = Random.Range(-1,2)* Random.Range(0,2);
		}
		if (rollTimer > rollWaitTime) {
			rollTimer = 0;
			rollWaitTime = Random.Range(1,3);
			targetRoll = Random.Range(-1,2) * Random.Range(0,2);
		}
		if (yawTimer > yawWaitTime) {
			yawTimer = 0;
			yawWaitTime = Random.Range(1,3);
			targetYaw = Random.Range(-1,2)* Random.Range(0,2);
		}

		pitchInput = Mathf.MoveTowards (pitchInput, targetPitch, Time.deltaTime);
		rollInput = Mathf.MoveTowards (rollInput, targetRoll, Time.deltaTime);
		yawInput = Mathf.MoveTowards (yawInput, targetYaw, Time.deltaTime);
		thrustInput = 1;
	}
	
	public override void FireWeapon () {
	
	}
}
