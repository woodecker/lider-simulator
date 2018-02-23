using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBackground : MonoBehaviour {

	Image canvasImage;

	void Start () {
		canvasImage = GetComponent<Image> ();
	}
	
	void Update () {

		bool anyActive = false;

		foreach (Transform child in transform)
		{
			if (child.gameObject.activeInHierarchy)
				anyActive = true;
		}

		canvasImage.enabled = anyActive;
	}
}
