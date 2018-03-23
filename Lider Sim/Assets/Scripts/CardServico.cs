using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardServico : MonoBehaviour {

	public Text name;
	public Text desc;
	public Text cost;
	public Text power;
	public Button buyButton;

	Servico myServico;

	public void SetServico (Servico s) 
	{
		name.text = s.name;
		desc.text = s.description;
		cost.text = "CUSTO: R$" + s.cost.ToString() + "";
		power.text = "ENERGIA: +" + s.energy.ToString() + "%";

		myServico = s;
	}

	public void BuyServico()
	{
		Projeto.Instance.orcamento -= myServico.cost;
		buyButton.interactable = false;
		buyButton.GetComponent<Image> ().color = Color.green;

		Projeto.Instance.currentServicos.Add (myServico);
	}
}
