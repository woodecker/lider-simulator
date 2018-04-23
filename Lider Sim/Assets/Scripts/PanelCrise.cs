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

	string randomName;

	public void Start () 
	{
		currentCrise = CriseController.Instance.RandomCrise ();

		string q = currentCrise.question;

		randomName = Projeto.Instance.Equipe [Random.Range (0, Projeto.Instance.Equipe.Count)].name;

		question.text = q.Replace ("{name1}", randomName);

		//Create answers
		foreach (Answers a in currentCrise.answers) {
			GameObject newButton = Instantiate (answerButton, buttonParent);
			newButton.GetComponent<AnswerButton> ().SetAnswer (a, this, randomName);
			myButtons.Add (newButton);
		}

		closeButton.SetActive (false);
	}

	public void SetFeedback (string message)
	{
		string q = message;
		q = q.Replace ("{name1}", randomName);

		feedback.text = q;
		closeButton.SetActive (true);

		foreach(GameObject b in myButtons){
			b.GetComponent<Button>().interactable = false;
		}
	}

}
