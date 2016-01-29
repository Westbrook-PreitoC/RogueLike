using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	public bool isPlayerTurn;
	public bool areEnemiesMoving;

	private BoardController boardController;	

	void Awake () {
		if(Instance != null && Instance != this) 
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		boardController = GetComponent<BoardController>();
	}

	void Start()
	{
		boardController.SetupLevel();
		isPlayerTurn = true;
		areEnemiesMoving = false;
	}

	void Update () {
		if (isPlayerTurn || areEnemiesMoving) 
		{
			return;
		}

		StartCoroutine(MoveEnemies());
	}

	private IEnumerator MoveEnemies()
	{
		areEnemiesMoving = true;

		yield return new WaitForSeconds(0.2f);

		//Code to make ALL enemies move on the game board

		areEnemiesMoving = false;
		isPlayerTurn = true;
	}
}
