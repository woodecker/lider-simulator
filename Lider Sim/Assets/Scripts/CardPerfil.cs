using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPerfil : MonoBehaviour {

	public Text name;
	public Text desc;

	public Image avatar;

	public Text organizacao;
	public Text programacao;
	public Text design;
	public Text criatividade;

	public Text cost;
	public Text power;

	public Button buyButton;

	Perfil myPerfil;

	public void SetPerfil (Perfil s) 
	{
		name.text = s.name;
		desc.text = s.description;

		organizacao.text = "ORGANIZAÇÃO: " + s.organizacao.ToString();
		programacao.text = "PROGRAMAÇÃO: " + s.programacao.ToString();
		design.text = "DESIGN: " + s.design.ToString();
		criatividade.text = "CRIATIVIDADE: " + s.criatividade.ToString();

		cost.text = "SALÁRIO: R$" + s.salario.ToString();
		power.text = "ENERGIA: 100%";

		avatar.sprite = s.avatar;

		myPerfil = s;
	}

	public void BuyPerfil()
	{
		Projeto.Instance.orcamento -= myPerfil.salario;
		buyButton.interactable = false;
		buyButton.GetComponent<Image> ().color = Color.green;

		Projeto.Instance.Equipe.Add (myPerfil);
		Projeto.Instance.ShowProfile (myPerfil.body);
	}
}
