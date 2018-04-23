﻿using System.Collections;
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

	const float T_NEWDAY = 5f;
	float newDayTime = 5f;
	bool paused = true;

	public GameObject painelTarefas;
	public GameObject painelFooter;

	public Text orgUI;
	public Text progUI;
	public Text dsgnUI;
	public Text criatUI;

	public SpriteRenderer buddy1;
	public SpriteRenderer buddy2;
	public SpriteRenderer buddy3;
	public SpriteRenderer buddy4;
	public SpriteRenderer buddy5;

	void Awake ()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start ()
	{
		buddy1.sprite = null;
		buddy2.sprite = null;
		buddy3.sprite = null;
		buddy4.sprite = null;
		buddy5.sprite = null;

		Time.timeScale = 3f;

		orcamentoInicial = orcamento;

		orcamentoText.text = Orcamento();

		timer.maxValue = 30;
		timer.value = dias;
	}

	public void ShowProfile(Sprite body){
		switch (Equipe.Count) {
		case 1:
			buddy1.sprite = body;
			break;
		case 2:
			buddy2.sprite = body;
			break;
		case 3:
			buddy3.sprite = body;
			break;
		case 4:
			buddy4.sprite = body;
			break;
		case 5:
			buddy5.sprite = body;
			break;
		}

	}

	string Orcamento(){
		decimal numb = orcamento;
		return "R$ " + numb.ToString("N");
	}

	void Update ()
	{
		if (!paused)
			newDayTime -= Time.deltaTime;

		if (newDayTime <= 0f) {
			NewDay ();
			newDayTime = T_NEWDAY;
		}

		orcamentoText.text = Orcamento();

		if (timer.value <= timer.minValue) {
			etapa.text = "Pré-produção";
		} else if (timer.value <= 29) {
			etapa.text = "Produção";
			painelFooter.SetActive (true);
		} else {
			etapa.text = "Pós-produção";
		}
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

		orgUI.text = organizacao.ToString ();
		progUI.text = programacao.ToString ();
		dsgnUI.text = design.ToString ();
		criatUI.text = criatividade.ToString ();
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
