using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody; 

	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
	}

	protected bool CanObjectMove(int xDirection, int yDirection)
	{
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, yDirection);

		StartCoroutine(SmoothMovementRoutine(endPosition));

		return true;
	}

	protected IEnumerator SmoothMovementRoutine(Vector2 endPosition) 
	{
		// Implement a set of intructions to smooth out movement
	}

	void Update () {
	
	}
}
