using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelServicos : MonoBehaviour {

	public GameObject prefabServico;
	public RectTransform parentServicos;

	public List<GameObject> myServices;

	public void Start () 
	{
		//Create services
		foreach (Servico s in ServicoController.Instance.servicos) 
		{
			GameObject newButton = Instantiate (prefabServico, parentServicos);
			newButton.GetComponent<CardServico> ().SetServico (s);
		}
	}

}
