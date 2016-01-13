using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {
	
	public int columns;
	public int rows;
	
	public GameObject[] floors;

	private Transform gameBoard;
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	private void SetupGameBoard()
	{
		gameBoard = new GameObject("Game Board").transform;

		for(int x = 0; x < columns; x++) 
		{
			for(int y = 0; y < rows; y++)
			{
				GameObject selectedTile = floors[Random.Range(0, floors.Length)];
				GameObject floorTile = (GameObject)Instantiate(selectedTile, new Vector3(x, y, 0f), Quaternion.identity);
				floorTile.transform.SetParent(gameBoard);
			}
		}
	}

	public void SetupLevel()
	{
		SetupGameBoard();
	}
}
