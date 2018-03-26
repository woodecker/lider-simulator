using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAppPausedScript : MonoBehaviour {

	bool isPaused = false;
	public GameObject PauseScreen;

	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseScreen.SetActive (true);
		} else {
			PauseScreen.SetActive (false);
		}
	}
	void OnApplicationFocus (bool hasFocus){
		isPaused = !hasFocus;
	}
	void OnApplicationPause (bool pauseStatus){
		isPaused = pauseStatus;
	}
}
