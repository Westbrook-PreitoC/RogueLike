using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public float moveTime = 0.1f;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody; 
	private LayerMask collisionLayer;
	private float inverseMoveTime;

	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
		rigidBody = GetComponent<Rigidbody2D>();
		collisionLayer = LayerMask.GetMask("Collision Layer");
		inverseMoveTime = 1.0f / moveTime;
	}

	protected virtual void Move(int xDirection, int yDirection)
	{
		bool canMove = CanObjectMove(xDirection, yDirection);

		if(canMove) 
		{
			return;	
		}

		//Handle anuy collisions that occurred
	}

	protected bool CanObjectMove(int xDirection, int yDirection)
	{
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, yDirection);

		boxCollider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast(startPosition, endPosition, collisionLayer);
		boxCollider.enabled = true;

		if(hit.transform == null)
		{
			StartCoroutine(SmoothMovementRoutine(endPosition));
			return true;
		}

		return true;
	}

	protected IEnumerator SmoothMovementRoutine(Vector2 endPosition) 
	{
		float remainingDistanceToEndPosition;

		do
		{
			remainingDistanceToEndPosition = (rigidBody.position - endPosition).sqrMagnitude;
			Vector2 updatedPosition = Vector2.MoveTowards(rigidBody.position, endPosition, inverseMoveTime * Time.deltaTime);
			rigidBody.MovePosition(updatedPosition);
			yield return null;
		}while(remainingDistanceToEndPosition > float.Epsilon);
	}

	void Update () {
	
	}
}
