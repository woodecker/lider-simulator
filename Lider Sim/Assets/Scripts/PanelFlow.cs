using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PanelFlow : MonoBehaviour {

	public Flowchart mainFlowchart;

	void Start(){
		mainFlowchart = FindObjectOfType<Flowchart> ();
	}

	public void GotoBlock(string block){
		mainFlowchart.ExecuteBlock (block);
	}
}
