using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {
	
	public Vector3 position;
	public List<NodeConnection> connections = new List<NodeConnection>();
	
	void Awake(){
		position = transform.position;
	}
	
	// Use this for initialization
	void Start () {
		for(int i=0;i<connections.Count;i++){
			// calculate the distance
			connections[i].distance = (connections[i].destinationNode.position-position).sqrMagnitude;
		}
	}
	
	void OnDrawGizmosSelected () {
		for(int i=0;i<connections.Count;i++){
			if(connections[i].destinationNode != null){
				Gizmos.DrawLine(transform.position, connections[i].destinationNode.transform.position);
			}
		}
	}
	
	
	
}
