using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	void Update () {
		if (!GameController.Instance.isPlayerTurn)
		{
			return;
		}

		int xAxis = 0;
		int yAxis = 0;

		xAxis = (int)Input.GetAxisRaw("Horizontal");
		yAxis = (int)Input.GetAxisRaw("Vertical");

		if (xAxis != 0) 
		{
			yAxis = 0;
		}

		if (xAxis != 0 || yAxis != 0) 
		{
			Move(xAxis, yAxis);
			GameController.Instance.isPlayerTurn = false;
		}

	}
}
