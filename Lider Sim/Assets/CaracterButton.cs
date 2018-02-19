using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracterButton : MonoBehaviour {

	public GameObject buttonClose;

	public void SelectAutoritario(int autoritario)
	{
		GetComponent<Button> ().interactable = false;
		GetComponent<Image> ().color = Color.green;

		Player.Instance.CaracteristicaAutoritaria (autoritario);
	}

	public void SelectDemocratico(int democratico)
	{
		GetComponent<Button> ().interactable = false;
		GetComponent<Image> ().color = Color.green;

		Player.Instance.CaracteristicaDemocratica (democratico);
	}

	public void SelectLeisse(int leisse)
	{
		GetComponent<Button> ().interactable = false;
		GetComponent<Image> ().color = Color.green;

		Player.Instance.CaracteristicaLeisse (leisse);
	}

	void Update()
	{
		if (Player.Instance.nCaracteristicas >= 3) 
		{
			buttonClose.SetActive (true);
			GetComponent<Button> ().interactable = false;
		}
	}
}
