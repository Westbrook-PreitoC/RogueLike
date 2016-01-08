using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public static GameController Instance;

	void Awake () {
		if (Instance != null && Instance != this) 
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	void Update () {
	
	}
}
