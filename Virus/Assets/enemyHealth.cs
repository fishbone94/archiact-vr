using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
	public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
	public int damage = 20;
	public float timerDeath = 0f;				// timer for worm death
	
	BoxCollider boxCollider;            // Reference to the capsule collider.
	bool isDead;                                // Whether the enemy is dead.
	GameObject player;
	playerHealth playerHealth;

	public GameObject worm2;
	float timer = 0.5f;					// timing second worm spawn

	void Awake ()
	{
		boxCollider = GetComponent <BoxCollider> ();
		currentHealth = startingHealth;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<playerHealth> ();
	}

	void Update() {
		if (currentHealth <= 0) {
			Split ();
			timer -= Time.deltaTime;
		}
	}

	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		// If the enemy is dead...
		if(isDead) 
			// ... no need to take damage so exit the function.
			return;
		
		// Reduce the current health by the amount of damage sustained.
		currentHealth -= amount;

		// If the current health is less than or equal to zero...
		if(currentHealth <= 0)
		{
			// ... the enemy is dead.
			Death ();
		}
	}
	
	
	void Death ()
	{
		// The enemy is dead.
		isDead = true;
		
		// Turn the collider into a trigger so shots can pass through it.
		boxCollider.isTrigger = true;
		Destroy (gameObject, timerDeath);
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
			playerHealth.takeDamage(damage);
			Destroy(gameObject);
		}
	}

	void Split(){
		if (timerDeath > 0 && timer == 0.5f) {
			Instantiate (worm2);
		}
		if (timerDeath > 0 && timer <= 0f) {
			Instantiate (worm2);
			timer = 0.6f;
		}
	}
}
