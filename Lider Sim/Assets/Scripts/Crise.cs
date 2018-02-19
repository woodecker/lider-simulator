using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crise", menuName = "Lidersim/Nova Crise")]
public class Crise : ScriptableObject {

	[TextAreaAttribute]
	public string question;
	public Answers[] answers;
}

[System.Serializable]
public struct Answers {
	[TextAreaAttribute]
	public string answer;
	[TextAreaAttribute]
	public string feedback;
	public int autoritario;
	public int democratico;
	public int leisse;
}