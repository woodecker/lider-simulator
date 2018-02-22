using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Servico", menuName = "Lidersim/Novo Servico")]
public class Servico : ScriptableObject {

	public string name;
	[TextAreaAttribute]
	public string description;
	public int cost;
	public int energy;
	public float productivityInc;
}