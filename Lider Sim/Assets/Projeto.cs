﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projeto : MonoBehaviour {

	public int orcamento = 50000;
	public Text orcamentoText;
	public Text lucrosText;

	public void Contratar(int salario){
		orcamento -= salario;
	}

	void Start(){
		orcamentoText.text = "R$ " + orcamento.ToString ();
	}

	void Update(){
		orcamentoText.text = "R$ " + orcamento.ToString ();
		lucrosText.text = "R$ " + orcamento.ToString ();
	}
}
