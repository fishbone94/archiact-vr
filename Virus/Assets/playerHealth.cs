using UnityEngine;
using System.Collections;

public class playerHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;

	bool isDead = false;
	bool damaged = false;

	void Awake () {
		currentHealth = startingHealth;
	}

	//just code for later use
	public void takeDamage (int amount) {
		damaged = true;
		currentHealth -= amount;

		if (currentHealth <= 0 && !isDead) {
			death();
		}
	}

	public void death() {
		isDead = true;
	}
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			takeDamage(5);
		}
	}
}
