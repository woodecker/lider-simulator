using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEscolherEquipe : MonoBehaviour {

	public GameObject prefabPerfil;
	public RectTransform parentPerfil;

	public List<GameObject> myPerfis;

	public void Start () 
	{
		//Create services
		foreach (Perfil s in ServicoController.Instance.perfis) 
		{
			GameObject newButton = Instantiate (prefabPerfil, parentPerfil);
			newButton.GetComponent<CardPerfil> ().SetPerfil (s);
		}
	}

}
