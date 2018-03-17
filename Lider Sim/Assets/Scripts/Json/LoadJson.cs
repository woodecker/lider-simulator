using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Fungus;

[System.Serializable]
public class GameData
{
	public int level;
	public float timeElapsed;
	public string playerName;
}

public class LoadJson : MonoBehaviour {

	public int level;
	public float timeElapsed;
	public string playerName;

	private string gameDataFileName = "data.json";

	public Flowchart flow;

	private void LoadGameData ()
	{
		// Path.Combine combines strings into a file path
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

		if(File.Exists(filePath))
		{
			// Read the json from the file into a string
			string dataAsJson = File.ReadAllText(filePath); 
			// Pass the json to JsonUtility, and tell it to create a GameData object from it
			GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

			// Retrieve the allRoundData property of loadedData
			level = loadedData.level;
			timeElapsed = loadedData.timeElapsed;
			playerName = loadedData.playerName;
		}
		else
		{
			Debug.LogError("Cannot load game data!");
		}
	}

	void Start () {

		LoadGameData ();

		flow.SetStringVariable ("PlayerName", playerName);
	}


	void SaveData () {
		
		GameData myObject = new GameData();
		myObject.level = 1;
		myObject.timeElapsed = 47.5f;
		myObject.playerName = "Dr Charles Francis";

		//serialize to json
		string json = JsonUtility.ToJson(myObject);
		Debug.Log (json);

		myObject.level = 2;

		//myObject = JsonUtility.FromJson<MyClass>(json);
		JsonUtility.FromJsonOverwrite(json, myObject);

		level = myObject.level;
		timeElapsed = myObject.timeElapsed;
		playerName = myObject.playerName;

		Debug.Log (myObject.level);
	}
	
	void Update () {
		
	}
}
