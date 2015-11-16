using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

	public GameObject ballPrefab;
	
	public Transform spawnPoint;
	
	public GameObject newBall;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// check if we pressed left click
		if(Input.GetMouseButtonUp(0) == true){
			// call the spawn ball function
			SpawnBall();
		}
		
	}
	
	void SpawnBall () {
		
		// instantiate the ball
		
		newBall = (GameObject)Instantiate (ballPrefab,spawnPoint.position, spawnPoint.rotation);
		newBall.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 5, ForceMode.VelocityChange);
	}
}












