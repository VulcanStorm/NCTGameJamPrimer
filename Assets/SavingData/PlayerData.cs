using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public struct PlayerData {

	public string playerName;
	public int playerHealth;
	public float xPos;
	public float yPos;
	public float zPos;
	
	public static bool DoSaveData (string filePath, PlayerData dataToSave) {
		
		try{
			// create the xml serialiser
			XmlSerializer xmlSerialiser = new XmlSerializer(typeof(PlayerData));
			// create a file stream
			// using statement: to ensure that the file is closed if an error occurs
			using(FileStream fileStream = new FileStream(filePath,FileMode.Create)){
				// now serialise the data
				xmlSerialiser.Serialize(fileStream,dataToSave);
				// now close the file
				fileStream.Close();
			}
		}
		
		catch(Exception e){
			Debug.LogException(e);
			return false;
		}
		return true;
		
	}
	
	public static PlayerData DoLoadData (string filePath){
		
		PlayerData returnData = new PlayerData();
		
		try{
			// create xml serialiser
			XmlSerializer xmlSerialiser = new XmlSerializer(typeof(PlayerData));
			// create file stream
			using(FileStream fileStream = new FileStream(filePath, FileMode.Open)){
				// get the return data
				returnData = (PlayerData)xmlSerialiser.Deserialize(fileStream);
				// close the file
				fileStream.Close ();
			}
			
		}
		catch (Exception e){
			Debug.LogException(e);
			
		}
		
		return returnData;
	}
	
}
