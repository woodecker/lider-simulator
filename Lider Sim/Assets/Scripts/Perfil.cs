using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perfil", menuName = "Lidersim/Novo Perfil")]
public class Perfil : ScriptableObject {

	public string name;
	public Sprite avatar;
	[TextAreaAttribute]
	public string description;
	public int organizacao = 100;
	public int programacao = 100;
	public int design = 100;
	public int criatividade = 100;
	public int salario = 2000;
}