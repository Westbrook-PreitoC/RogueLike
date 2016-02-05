using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public static SoundController Instance;

	void Awake () {
		if (Instance != null && Instance != this) 
		{
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
	
}
