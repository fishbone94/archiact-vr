﻿using UnityEngine;
using System.Collections;

public class WormHealth1 : MonoBehaviour {
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
	public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
	public int damage = 20;
	
	
	BoxCollider boxCollider;            // Reference to the capsule collider.
	bool isDead;                                // Whether the enemy is dead.
	GameObject player;
	playerHealth playerHealth;
	
	
	void Awake ()
	{
		boxCollider = GetComponent <BoxCollider> ();
		currentHealth = startingHealth;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<playerHealth> ();
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
	
	
	IEnumerator Death ()
	{
		// The enemy is dead.
		isDead = true;
		
		// Turn the collider into a trigger so shots can pass through it.
		boxCollider.isTrigger = true;
		Split ();
		yield return new WaitForSeconds(1);
		Split ();
		Destroy (gameObject);
	}
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "First Person Controller") {
			playerHealth.takeDamage(damage);
			Destroy(gameObject);
		}
	}
	
	void Split(){
		GameObject Worm2 = (GameObject)Instantiate(Resources.Load("Worm2"));
	}
}
