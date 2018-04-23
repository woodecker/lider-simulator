using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRelatorio : MonoBehaviour {

	public Text pontosOR;
	public Text pontosPR;
	public Text pontosDE;
	public Text pontosCR;

	public Text produtividade;

	public Text orcamento;
	public Text lucros;

	public Text lideranca;
	public Text liderancaDesc;
	public Text pontosDesc;

	void Update()
	{
		pontosOR.text = Projeto.Instance.PontosOR ();
		pontosOR.text = Projeto.Instance.PontosPR ();
		pontosOR.text = Projeto.Instance.PontosDE ();
		pontosOR.text = Projeto.Instance.PontosCR ();

		produtividade.text = Projeto.Instance.Produtividade ().ToString () + "%";

		orcamento.text = Money(Projeto.Instance.orcamentoInicial);
		lucros.text = Money(Projeto.Instance.orcamento);

		lideranca.text = Player.Instance.PerfilLideranca ();
		liderancaDesc.text = Player.Instance.PerfilLiderancaDesc ();

		if(Projeto.Instance.Produtividade () <= 75f)
			pontosDesc.text = "Para o próximo projeto tente contratar mais bonificações para os trabalhadores.";
		else
			pontosDesc.text = "Seus trabalhadores estão contentes e conseguem dar o melhor de si.";
	}

	string Money(int money){
		decimal numb = money;
		return "R$ " + numb.ToString("N");
	}
}
