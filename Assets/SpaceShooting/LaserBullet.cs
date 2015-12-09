using UnityEngine;
using System.Collections;

public class LaserBullet : MonoBehaviour {
	
	public int velocity = 30;
	
	float deathTimer = 0;
	float deathTime = 5;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*velocity, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		deathTimer += Time.deltaTime;
		
		if(!(deathTimer < deathTime)){
			Destroy (gameObject);
		}
	}
	
	void Fire () {
		
	}
}
