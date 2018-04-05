using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player Instance;

	public int pontosAT;
	public int pontosDE;
	public int pontosLA;

	public int nCaracteristicas = 0;

	public int lucros;

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

	public string PerfilLideranca()
	{
		if (pontosAT > pontosDE) {
			if (pontosAT > pontosLA) {
				return "AUTORITÁRIO";
			} else {
				return "Laissez-faire";
			}
		} else {
			if (pontosDE > pontosLA) {
				return "DEMOCRÁTICO";
			} else {
				return "Laissez-faire";
			}
		}
	}

	public string PerfilLiderancaDesc()
	{
		if (pontosAT > pontosDE) {
			if (pontosAT > pontosLA) {
				return "Parabéns na resolução de problemas, só tente ser menos autoritário.";
			} else {
				return "Tente organizar melhor o projeto e os trabalhadores.";
			}
		} else {
			if (pontosDE > pontosLA) {
				return "Muito bem. Você se destaca como líder.";
			} else {
				return "Tente organizar melhor o projeto e os trabalhadores.";
			}
		}
	}

}
