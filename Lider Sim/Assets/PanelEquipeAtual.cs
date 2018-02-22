using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEquipeAtual : MonoBehaviour {

	public GameObject prefabPerfil;
	public RectTransform parentPerfil;

	public List<GameObject> myPerfis;

	public void Start () 
	{
		//Create services
		foreach (Perfil s in Projeto.Instance.Equipe) 
		{
			GameObject newButton = Instantiate (prefabPerfil, parentPerfil);
			newButton.GetComponent<CardPerfil> ().SetPerfil (s);
		}
	}
}
