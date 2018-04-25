using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChangeVolumeScript : MonoBehaviour {

	public Slider volumeSlider;
	public AudioMixer mixer;

	void Start (){
		mixer.SetFloat ("Volume", volumeSlider.value);
	}

	public void VolumeController(float volume){
		mixer.SetFloat ("Volume", volume);
	}
}
