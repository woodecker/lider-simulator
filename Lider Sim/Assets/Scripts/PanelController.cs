using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelController : MonoBehaviour {

	public GameObject[] panels;

	public int currentPanel;

	public static PanelController Instance;

	public Text etapa;
	public Slider timer;

	void Awake(){
		if (Instance == null)
			Instance = this;
	}

	public void NextPanel(){
		
		foreach (GameObject panel in panels) {
			panel.SetActive (false);
		}

		currentPanel++;
		if (currentPanel >= panels.Length)
			currentPanel = 0;

		panels [currentPanel].SetActive (true);
	}

	void Update(){
		if (currentPanel <= 11)
			etapa.text = "PRE-PRODUÇÃO";
		else if (currentPanel <= 14)
			etapa.text = "PRODUÇÃO";
		else
			etapa.text = "POS-PRODUÇÃO";

		timer.maxValue = panels.Length;
		timer.value = currentPanel;
	}


}