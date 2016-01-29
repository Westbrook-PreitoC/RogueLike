using UnityEngine;
using System.Collections;

public class Enemy : MovingObject {
	
	protected override void Start () {
		GameController.Instance.AddEnemyToList(this);
		base.Start();
	}

	void Update () {
	
	}
}
