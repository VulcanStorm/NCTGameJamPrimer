using UnityEngine;
using System.Collections;

public class Simple_Space_Plane : MonoBehaviour {
	
	public GameObject laserBulletPrefab = null;
	public Transform firePoint;
	
	public int pitchSpeed = 60;
	public int rollSpeed = 90;
	public int yawSpeed = 30;
	public int thrustSpeed = 10;
	public float fireTime = 0.333f;
	

	protected float pitchInput = 0;
	protected float rollInput = 0;			
	protected float yawInput = 0;
	protected float thrustInput = 0;
	
	protected float fireTimer = 0;
	
	Rigidbody thisRigidbody;
	Transform thisTransform;

	// Use this for initialization
	void Start () {
		thisRigidbody = this.GetComponent<Rigidbody> ();
		thisTransform = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		// get input
		GetInput ();
		
		FireWeapon();
	}

	public virtual void GetInput () {
		// turning
		pitchInput = -Input.GetAxis ("Mouse Y");
		rollInput = -Input.GetAxis ("Mouse X");
		yawInput = Input.GetAxis ("Horizontal");
		
		// thrusters :D
		thrustInput = Input.GetAxis("Vertical");
	}
	
	public virtual void FireWeapon () {
	fireTimer += Time.deltaTime;
		if(Input.GetMouseButtonDown(0) && fireTimer > fireTime){
		 	fireTimer = 0;
			Instantiate(laserBulletPrefab, firePoint.position, firePoint.rotation);
		}
	}
	
	void FixedUpdate () {

		thisTransform.Rotate (Vector3.right * pitchInput * pitchSpeed * Time.deltaTime, Space.Self);
		thisTransform.Rotate (Vector3.up * yawInput * yawSpeed * Time.deltaTime, Space.Self);
		thisTransform.Rotate (Vector3.forward * rollInput * rollSpeed * Time.deltaTime, Space.Self);

		thisTransform.Translate (Vector3.forward * thrustInput * thrustSpeed * Time.deltaTime, Space.Self);
	}
}
