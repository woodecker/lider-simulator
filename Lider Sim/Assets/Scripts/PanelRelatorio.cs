using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelRelatorio : MonoBehaviour {

	public Text pontosProjeto;
	public Text produtividade;

	public Text orcamento;
	public Text lucros;

	public Text lideranca;
	public Text liderancaDesc;
	public Text pontosDesc;

	void Update()
	{
		pontosProjeto.text = Projeto.Instance.PontosProjeto ().ToString ();
		produtividade.text = Projeto.Instance.Produtividade ().ToString ();

		orcamento.text = Projeto.Instance.orcamentoInicial.ToString ();
		lucros.text = Projeto.Instance.orcamento.ToString ();

		lideranca.text = "Perfil de Liderança: " + Player.Instance.PerfilLideranca ();
		liderancaDesc.text = Player.Instance.PerfilLiderancaDesc ();

		if(Projeto.Instance.Produtividade () < 50)
			pontosDesc.text = "Tente contratar mais serviços pro trabalhador.";
		else
			pontosDesc.text = "Seus trabalhadores estão contentes e souberam dar o melhor de si.";
	}
}
