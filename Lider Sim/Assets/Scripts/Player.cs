using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player Instance;

	public int pontosAT;
	public int pontosDE;
	public int pontosLA;

	public int nCaracteristicas = 0;

	//public int lucros;

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
		if (Projeto.Instance.orcamento > 1000) {
			if (pontosAT > pontosDE) {
				return "Parabéns na resolução de problemas, mas tente ser menos autoritário.";
			} else {
				return "Muito bem. Você se destacou como líder.";
			}
		} else {
			if (pontosLA > pontosDE) {
				return "Tente organizar melhor o projeto e os trabalhadores.";
			} else {
				return "Faltou um controle maior dos gastos.";
			}
		}

	}

}
