using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public int dmg = 20;
	public int speed = 20;
	public float deathTime = 5;
	float timer = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
	}
	
	void Update () {
		timer += Time.deltaTime;
		if(timer > deathTime){
			Destroy (this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision col){
		//Debug.Log ("HAHA COLLISION!");
		if(col.transform.root.tag == "Tank"){
			TankShoot hitScript = col.transform.root.GetComponent<TankShoot>();
			hitScript.TakeDamage(dmg);
		}
		Destroy (this.gameObject);
	}
}
