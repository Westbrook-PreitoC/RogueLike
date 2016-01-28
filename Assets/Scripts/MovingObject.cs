using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody; 

	void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	protected bool CanObjectMove(int xDirection, int yDirection)
	{
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, yDirection);

		rigidBody.MovePosition(endPosition);

		return true;
	}

	void Update () {
	
	}
}
