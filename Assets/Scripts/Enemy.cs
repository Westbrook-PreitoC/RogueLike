using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {

	private Transform player;

	protected override void Start () {
		GameController.Instance.AddEnemyToList(this);
		player = GameObject.FindGameObjectWithTag("Player").transform;
		base.Start();
	}

	void Update () {
	
	}
}
