using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {

	private Transform player;

	protected override void Start () {
		GameController.Instance.AddEnemyToList(this);
		player = GameObject.FindGameObjectWithTag("Player").transform;
		base.Start();
	}

	public void MoveEnemy() 
	{
		int xAxis = 0;
		int yAxis = 0;

		float xAxisDistance = Mathf.Abs(player.position.x - transform.position.x);
		float yAxisDistance = Mathf.Abs(player.position.y - transform.position.y);

		if (xAxisDistance > yAxisDistance) {
			if (player.position.x > transform.position.x) {
				xAxis = 1;
			} else {
				xAxis = -1;
			}
		} 
		else 
		{
			if(player.position.y > transform.position.y) 
			{
				yAxis = 1;
			}
			else 
			{
				yAxis = -1;
			}
		}

		CanObjectMove(xAxis, yAxis);
	}
}
