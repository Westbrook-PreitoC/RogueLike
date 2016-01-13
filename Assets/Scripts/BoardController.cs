using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour {
	
	public int columns;
	public int rows;
	
	public GameObject[] floors;
	public GameObject[] outerWalls;

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
				GameObject selectedTile;
				if(x == 0 || y == 0 || x == columns - 1 || y == rows - 1)
				{
					selectedTile = outerWalls[Random.Range(0, outerWalls.Length)];
				}
				else
				{
					selectedTile = floors[Random.Range(0, floors.Length)];
				}
				GameObject floorTile = (GameObject)Instantiate(selectedTile	, new Vector3(x, y, 0f), Quaternion.identity);
				floorTile.transform.SetParent(gameBoard);
			}
		}
	}

	public void SetupLevel()
	{
		SetupGameBoard();
	}
}
