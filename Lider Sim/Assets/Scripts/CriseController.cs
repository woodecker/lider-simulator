using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CriseController : MonoBehaviour {

	public static CriseController Instance;

	public List<Crise> crises;

	Crise currentCrise;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	public Crise RandomCrise () 
	{
		//Get random crisis
		int randomCrise = Random.Range (0, crises.Count);
		currentCrise = crises[randomCrise];
		crises.Remove (currentCrise);

		return currentCrise;
	}

}
