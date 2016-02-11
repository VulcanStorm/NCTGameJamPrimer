using UnityEngine;
using System.Collections;

public class PlayerSaveScript : MonoBehaviour {
	
	public PlayerData myPlayerData = new PlayerData();
	public string saveFilePath;
	
	
	// Use this for initialization
	void Start () {
		saveFilePath = Application.dataPath + "/testsave.sav";
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect(0,0,100,25),"Save")){
			PlayerData.DoSaveData(saveFilePath,myPlayerData);
		}
		
		if(GUI.Button(new Rect(0,30,100,25),"Load")){
			myPlayerData = PlayerData.DoLoadData(saveFilePath);
		}
	}
}
