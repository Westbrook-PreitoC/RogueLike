using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject {

	public Text healthText;

	private Animator animator;
	private int playerHealth;
	private int attackPower = 1;
	private int healthPerFruit = 5;
	private int healthPerSoda = 10;
	private int secondsUntilNextLevel = 1;

	protected override void Start()
	{
		base.Start();
		animator = GetComponent<Animator>();
		playerHealth = GameController.Instance.playerCurrentHealth;
		healthText.text = "Health: " + playerHealth; 
	}

	private void OnDisable()
	{
		GameController.Instance.playerCurrentHealth = playerHealth;
	}

	void Update () {
		if(!GameController.Instance.isPlayerTurn)
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
			playerHealth--;
			healthText.text = "Health: " + playerHealth;
			Move<Wall>(xAxis, yAxis);
			GameController.Instance.isPlayerTurn = false;
		}

	}

	private void OnTriggerEnter2D(Collider2D objectPlayerCollidedWith)
	{
		if(objectPlayerCollidedWith.tag == "Exit") 
		{
			Invoke("LoadNewLevel", secondsUntilNextLevel);
		} 
		else if(objectPlayerCollidedWith.tag == "Fruit") 
		{
			playerHealth += healthPerFruit;
			healthText.text = "+" + healthPerFruit + " Health\n" + "Health: " + playerHealth;
			objectPlayerCollidedWith.gameObject.SetActive(false);
		} 
		else if(objectPlayerCollidedWith.tag == "Soda") 
		{
			playerHealth += healthPerSoda;
			healthText.text = "+" + healthPerSoda + " Health\n" + "Health: " + playerHealth;
			objectPlayerCollidedWith.gameObject.SetActive(false);
		}
	}

	private void LoadNewLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	protected override void HandleCollision<T>(T component)
	{
		Wall wall = component as Wall;
		animator.SetTrigger("playerAttack"); 
		wall.DamageWall(attackPower);
	}

	public void TakeDamage(int damageRecieved)
	{
		playerHealth -= damageRecieved;
		healthText.text = "-" + damageRecieved + " Health\n\t" + "Health: " + playerHealth;
		animator.SetTrigger("playerHurt");
	}
}
