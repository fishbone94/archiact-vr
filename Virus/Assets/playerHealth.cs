using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;

	public bool isDead = false;

	void Awake () {
		currentHealth = startingHealth;
	}

	//just code for later use
	public void takeDamage (int amount) {
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			death();
		}
	}

	public void death() {
		isDead = true;
	}
	
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Enemy") {
			takeDamage(20);
		}
	}
}
