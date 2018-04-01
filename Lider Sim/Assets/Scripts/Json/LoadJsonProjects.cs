using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.IO; 
using Fungus; 
using UnityEngine.UI;

[System.Serializable] 
public class Project 
{ 
	public string quantidadeAnotacoes; 
	public string nota1; 
	public string nota2;
	public string nota3;
}

public class LoadJsonProjects : MonoBehaviour { 
	
	private string gameDataFileName = "projetos.json"; 

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
			int rnd = Random.Range(0,2);

			switch (rnd) {
			case 0:
				flow.SetStringVariable ("Projeto", loadedData.nota1);
				break;
			case 1:
				flow.SetStringVariable ("Projeto", loadedData.nota2);
				break;
			case 2:
				flow.SetStringVariable ("Projeto", loadedData.nota3);
				break;
			}
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
	}
} 