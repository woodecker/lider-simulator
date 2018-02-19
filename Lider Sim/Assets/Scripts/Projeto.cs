using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projeto : MonoBehaviour {

	public static Projeto Instance;

	public int orcamento = 50000;
	public int orcamentoInicial;
	public Text orcamentoText;

	public List<Servico> currentServicos;
	public List<Perfil> Equipe;

	public int organizacao;
	public int programacao;
	public int design;
	public int criatividade;

	public int dias;
	public int energy;

	public Text etapa;
	public Slider timer;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start ()
	{
		orcamentoInicial = orcamento;

		orcamentoText.text = "R$ " + orcamento.ToString ();

		timer.maxValue = 30;
		timer.value = dias;
	}

	void Update ()
	{
		orcamentoText.text = "R$ " + orcamento.ToString ();

		if (timer.value <= 1)
			etapa.text = "PRE-PRODUÇÃO";
		else if (timer.value <= 29)
			etapa.text = "PRODUÇÃO";
		else
			etapa.text = "POS-PRODUÇÃO";
	}

	public void StartProject ()
	{
		InvokeRepeating ("NewDay", 0f, 30f);
	}

	public void NewDay ()
	{
		dias++;
		timer.value = dias;

		organizacao++;
		programacao++;
		design++;
		criatividade++;
		energy++;
	}

	public void Contratar (int salario)
	{
		orcamento -= salario;
	}
		
	public int PontosProjeto ()
	{
		return (organizacao + programacao + design + criatividade) / 4;
	}

	public int Produtividade()
	{
		return energy;
	}

}
