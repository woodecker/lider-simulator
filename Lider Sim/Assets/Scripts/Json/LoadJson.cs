using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.IO; 
using Fungus; 
using UnityEngine.UI;
using System.Text.RegularExpressions;

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

		#if UNITY_STANDALONE_OSX
		string filePath = Path.Combine(Application.dataPath + "/Data/Assets/Resources/", gameDataFileName);
		#else
		string filePath = Path.Combine("Assets/Resources/", gameDataFileName); 
		#endif

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

			nota1.text = loadedData.nota1.Replace ("\\n", "\n").Replace ("\\r", "\r");
			nota2.text = loadedData.nota2.Replace ("\\n", "\n").Replace ("\\r", "\r");
			nota3.text = loadedData.nota3.Replace ("\\n", "\n").Replace ("\\r", "\r");

			ShowUrl (nota1.text);
			ShowUrl (nota2.text);
			ShowUrl (nota3.text);
		} 
		else 
		{ 
			Debug.LogError("Cannot load game data!"); 
		} 
	}

	void ShowUrl(string textWithUrl)
	{
		//foreach (Match item in Regex.Matches(textWithUrl, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
		foreach (Match item in Regex.Matches(textWithUrl, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
		{
			Debug.Log(item.Value);
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