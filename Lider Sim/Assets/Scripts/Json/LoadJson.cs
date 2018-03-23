﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.IO; 
using Fungus; 
using UnityEngine.UI;

[System.Serializable] 
public class Notes 
{ 
	public string quantidadeAnotacoes; 
	public string nota1; 
	public string nota2;
	public string nota3;
	public string nota4;
	public string nota5;
	public string nota6;
	public string nota7;
}

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
	public Text nota1;
	public Text nota2;
	public Text nota3;

	private string gameDataFileName = "anotacoes.json"; 

	public Flowchart flow; 

	private void LoadGameData () 
	{ 
		// Path.Combine combines strings into a file path 
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build 
		//string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName); 
		//string filePath = Path.Combine(Application.dataPath + "/Resources/", gameDataFileName); 
		string filePath = Path.Combine("Assets/Resources/", gameDataFileName); 

		if(File.Exists(filePath)) 
		{ 
			// Read the json from the file into a string 
			string dataAsJson = File.ReadAllText(filePath, System.Text.UTF8Encoding.UTF8);  
			// Pass the json to JsonUtility, and tell it to create a GameData object from it 
			Notes loadedData = JsonUtility.FromJson<Notes>(dataAsJson); 

			// Retrieve the allRoundData property of loadedData 
			int notas;

			if(int.TryParse(loadedData.quantidadeAnotacoes, out notas)){
				level = notas;
			}

			nota1.text = loadedData.nota1;
			nota2.text = loadedData.nota2; 
			nota3.text = loadedData.nota3; 
		} 
		else 
		{ 
			Debug.LogError("Cannot load game data!"); 
		} 
	} 

	string ManageText(string InText){
		int cIndex = InText.IndexOf ("\n");
		InText = InText.Remove (cIndex);
		//InText = InText.Insert (cIndex, "\\n");
		return InText;
	}

	void Start () { 

		LoadGameData (); 

		//flow.SetStringVariable ("PlayerName", playerName); 
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