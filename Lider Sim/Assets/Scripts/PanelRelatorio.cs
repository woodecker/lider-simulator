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

	void Update()
	{
		pontosProjeto.text = Projeto.Instance.PontosProjeto ().ToString ();
		produtividade.text = Projeto.Instance.Produtividade ().ToString ();

		orcamento.text = Projeto.Instance.orcamentoInicial.ToString ();
		lucros.text = Projeto.Instance.orcamento.ToString ();

		lideranca.text = "Perfil de Liderança: " + Player.Instance.PerfilLideranca ();
	}
}
