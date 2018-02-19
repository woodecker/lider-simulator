using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player Instance;

	public int pontosAT;
	public int pontosDE;
	public int pontosLA;

	public int nCaracteristicas = 0;

	void Awake(){
		if (Instance == null)
			Instance = this;
	}

	public void CaracteristicaAutoritaria(int pontos){
		pontosAT += pontos;
		nCaracteristicas++;

	}

	public void CaracteristicaDemocratica(int pontos){
		pontosDE += pontos;
		nCaracteristicas++;
	}

	public void CaracteristicaLeisse(int pontos){
		pontosLA += pontos;
		nCaracteristicas++;
	}

}
