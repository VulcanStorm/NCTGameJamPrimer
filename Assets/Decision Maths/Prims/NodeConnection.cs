using UnityEngine;
using System.Collections;

[System.Serializable]
public class NodeConnection {
	
	public float distance;
	public Node destinationNode;
	
	NodeConnection () {
		
	}
	
	~NodeConnection () {
		destinationNode = null;
	}
}
