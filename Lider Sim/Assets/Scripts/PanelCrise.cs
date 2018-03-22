using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCrise : MonoBehaviour {

	public Text question;
	public GameObject answerButton;
	public RectTransform buttonParent;
	public Text feedback;
	public GameObject closeButton;

	Crise currentCrise;
	public List<GameObject> myButtons;

	public void Start () 
	{
		currentCrise = CriseController.Instance.RandomCrise ();

		string q = currentCrise.question;
		q = q.Replace ("XXXX", "Laura");
		q = q.Replace ("ZZZ", "Marta");
		q = q.Replace ("MM", "Carlos");
		q = q.Replace ("LLL", "Joao");

		question.text = q;

		//Create answers
		foreach (Answers a in currentCrise.answers) {
			GameObject newButton = Instantiate (answerButton, buttonParent);
			newButton.GetComponent<AnswerButton> ().SetAnswer (a, this);
			myButtons.Add (newButton);
		}

		closeButton.SetActive (false);
	}

	public void SetFeedback (string message)
	{
		string q = message;
		q = q.Replace ("XXXX", "Laura");
		q = q.Replace ("ZZZ", "Marta");
		q = q.Replace ("MM", "Carlos");
		q = q.Replace ("LLL", "Joao");

		feedback.text = q;
		closeButton.SetActive (true);

		foreach(GameObject b in myButtons){
			b.GetComponent<Button>().interactable = false;
		}
	}

}
