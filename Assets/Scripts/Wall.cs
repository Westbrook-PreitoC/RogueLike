	using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	public int hitPoints = 2;

	void Start () {
	
	}

	public void DamageWall(int damageRecieved)
	{
		hitPoints -= damageRecieved;
		if (hitPoints <= 0) 
		{
			gameObject.SetActive(false);
		}
	}


}
