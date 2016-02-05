using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	public bool isPlayerTurn;
	public bool areEnemiesMoving;
	public int playerCurrentHealth = 50;

	private BoardController boardController;
	private List<Enemy> enemies;
	private GameObject levelImage;
	private Text levelText;

	void Awake () {
		if(Instance != null && Instance != this) 
		{
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
		boardController = GetComponent<BoardController>();
		enemies = new List<Enemy>();
	}

	void Start()
	{
		InitializeGame();
	}

	private void InitializeGame()
	{
		levelImage = GameObject.Find("Level Image");
		levelText = GameObject.Find("Level Text").GetComponent<Text>();
		levelImage.SetActive(true);
		enemies.Clear();
		boardController.SetupLevel();
		isPlayerTurn = true;
		areEnemiesMoving = false;
	}

	private void OnLevelWasLoaded(int levelLoaded) 
	{
		InitializeGame();
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

		foreach(Enemy enemy in enemies) 
		{
			enemy.MoveEnemy();
			yield return new WaitForSeconds(enemy.moveTime);
		}

		areEnemiesMoving = false;
		isPlayerTurn = true;
	}

	public void AddEnemyToList(Enemy enemy)
	{
		enemies.Add(enemy);
	}
}
