using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

	private Answers answer;
	private PanelCrise panel;

	public void SetAnswer (Answers a, PanelCrise p, string currentName)
	{
		answer = a;
		panel = p;

		string ans = answer.answer;
		ans = ans.Replace ("{name1}", currentName);

		GetComponentInChildren<Text> ().text = ans;
	}

	public void SelectAnswer ()
	{
		panel.SetFeedback (answer.feedback);

		Player.Instance.pontosAT += answer.autoritario;
		Player.Instance.pontosDE += answer.democratico;
		Player.Instance.pontosLA += answer.leisse;

		GetComponent<Button> ().interactable = false;
		GetComponent<Button> ().image.color = Color.green;
	}
}
