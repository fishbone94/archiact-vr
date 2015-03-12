using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
	public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
	
	BoxCollider boxCollider;            // Reference to the capsule collider.
	bool isDead;                                // Whether the enemy is dead.
	
	
	void Awake ()
	{
		boxCollider = GetComponent <BoxCollider> ();
		currentHealth = startingHealth;
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

		Destroy (gameObject);
	}
}
