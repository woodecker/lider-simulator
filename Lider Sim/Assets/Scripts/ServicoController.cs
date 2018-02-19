using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServicoController : MonoBehaviour {

	public static ServicoController Instance;

	public Servico[] servicos;
	public Perfil[] perfis;

	void Awake(){
		if (Instance == null)
			Instance = this;
	}
}
