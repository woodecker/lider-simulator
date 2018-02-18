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

		question.text = currentCrise.question;

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
		feedback.text = message;
		closeButton.SetActive (true);

		foreach(GameObject b in myButtons){
			b.GetComponent<Button>().interactable = false;
		}
	}

}
