#pragma strict

public var thisTransform : Transform = null;

//public var mouseX : float = 0;
public var mouseY : float = 0;

public var minAngle : float = -75;
public var maxAngle : float = 80;

public var cameraRot : Vector3 = Vector3.zero;
public var camSpeed : float = 10;
function Start () {
	thisTransform = this.transform;
}

function Update () {
	
	//mouseX = Input.GetAxis("Mouse X");
	mouseY = -Input.GetAxis("Mouse Y");
	
}

// called after rendering the frame
function LateUpdate () {
	
	cameraRot.x += mouseY * camSpeed;
	
	cameraRot.x = Mathf.Clamp(cameraRot.x,minAngle, maxAngle);	
	
	thisTransform.localEulerAngles = cameraRot;

}