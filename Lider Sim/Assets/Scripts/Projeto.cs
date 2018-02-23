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

	const float T_NEWDAY = 30f;
	float newDayTime = 30f;
	bool paused = true;

	public GameObject painelTarefas;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start ()
	{
		Time.timeScale = 3f;

		orcamentoInicial = orcamento;

		orcamentoText.text = "R$ " + orcamento.ToString ();

		timer.maxValue = 30;
		timer.value = dias;
	}

	void Update ()
	{
		if (!paused)
			newDayTime -= Time.deltaTime;

		if (newDayTime <= 0f) {
			NewDay ();
			newDayTime = T_NEWDAY;
		}

		orcamentoText.text = "R$ " + orcamento.ToString ();

		if (timer.value <= timer.minValue)
			etapa.text = "PRE-PRODUÇÃO";
		else if (timer.value <= 29)
			etapa.text = "PRODUÇÃO";
		else
			etapa.text = "POS-PRODUÇÃO";
	}

	public void StartProject ()
	{
		painelTarefas.SetActive (true);

		paused = false;

		dias++;
		timer.value = dias;
	}

	public void ContinueProject ()
	{
		paused = false;
	}

	public void NewDay ()
	{
		dias++;
		timer.value = dias;

		//para cada perfil somar pontos no total do projeto
		foreach(Perfil p in Equipe)
		{
			organizacao += p.organizacao;
			programacao += p.programacao;
			design += p.design;
			criatividade += p.criatividade;
			energy++;
		}

		//Dia de pagamento, 7 meses projeto
		if (dias % 4 == 0)
		{
			foreach(Perfil p in Equipe){
				orcamento -= p.salario;
			}
		}

		if(dias == 30)
		{
			Fungus.Flowchart.BroadcastFungusMessage ("TempoAcabado");
			paused = true;
		}
		/*else if (dias % 7 == 0)
		{
			Fungus.Flowchart.BroadcastFungusMessage ("NovoMinigame");
			paused = true;
		}*/
		else if (dias % 5 == 0)
		{
			Fungus.Flowchart.BroadcastFungusMessage ("NovaCrise");
			paused = true;
		}


	}

	public void Contratar (int salario)
	{
		orcamento -= salario;
	}

	//Distribuição dos pontos dos perfis
	public string PontosProjeto ()
	{
		if (dias > 0)
			return "Organização " + (organizacao / dias / 10).ToString () + "/" + Equipe.Count * 10 +
			" Programação " + (programacao / dias / 10).ToString () + "/" + Equipe.Count * 10 +
			" Design " + (design / dias / 10).ToString () + "/" + Equipe.Count * 10 +
			" Criatividade " + (criatividade / dias / 10).ToString () + "/" + Equipe.Count * 10;
		else
			return "";
	}

	//Aumenta se contratou serviços e resolveu minigames
	public float Produtividade()
	{
		float p = 50f;
		foreach(Servico s in currentServicos){
			p = p * s.productivityInc;
		}
		return p;
	}

}
