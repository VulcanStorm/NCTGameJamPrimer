#pragma strict
@script RequireComponent(Rigidbody)

/*

!HI EVERYONE!

*/

public var thisTransform : Transform = null;
public var thisRigidbody : Rigidbody = null;

public var moveSpeed : float = 1.5;
public var runSpeed : float= 4;
public var turnSpeed : float = 3;
public var isRunning : boolean = false;

private var moveInputPos : Vector3 = Vector3.zero;
private var targetMovePos : Vector3 = Vector3.zero;
private var rotInput : Vector3 = Vector3.zero;
private var targetRotation : Quaternion = Quaternion.identity;

private var walkAxis : float = 0;
private var strafeAxis : float = 0;
private var mouseX : float = 0;


// called when the object starts
function Start () {
	thisTransform = this.transform;
	thisRigidbody = this.GetComponent(Rigidbody);
}

// called once per frame
function Update () {
	walkAxis = Input.GetAxis("Vertical");
	strafeAxis = Input.GetAxis("Horizontal");
	mouseX = Input.GetAxis("Mouse X");
	
	if(Input.GetKey(KeyCode.LeftShift)){
		isRunning = true;
	}
	else{
		isRunning = false;
	}
}

// called every fixed timestep
function FixedUpdate () {
	
	moveInputPos.x = strafeAxis;
	moveInputPos.z = walkAxis;
	moveInputPos = thisTransform.InverseTransformDirection(moveInputPos);
	if(isRunning == true){
		moveInputPos = moveInputPos.normalized * runSpeed * Time.deltaTime;
	}
	else{
		moveInputPos = moveInputPos.normalized * moveSpeed * Time.deltaTime;
	}
	
	rotInput.y += mouseX * turnSpeed;
	
	targetRotation = Quaternion.Euler(rotInput);
	
	targetMovePos = thisRigidbody.position + moveInputPos;
	thisRigidbody.MoveRotation(targetRotation);
	thisRigidbody.MovePosition(targetMovePos);
	
}