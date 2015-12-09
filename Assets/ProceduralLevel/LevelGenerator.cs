using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	
	// chunk width
	public uint chunkWidth = 10;
	// list of prefabs we can spawn
	public GameObject[] chunkPrefabs;
	
	// Use this for initialization
	void Start () {
		// create the level
		SpawnFullLevel(10);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// spawn an entire level
	void SpawnFullLevel (uint levelLength) {
		
		// create chunks until at level length
		for(uint i=0; i<levelLength; i++){
			
			// set the chunk spawn pos
			Vector3 chunkSpawnPos = Vector3.right;
			// set it to a multiple of i
			chunkSpawnPos.x = chunkSpawnPos.x * i * chunkWidth;
			
			uint blockType = 0;
			blockType = (uint)Random.Range(0,3);
			
			// create the chunk at this position
			Instantiate(chunkPrefabs[blockType], chunkSpawnPos, Quaternion.identity);
		}
		
	}
}














