using UnityEngine;
using System.Collections;

public class enemyAura : MonoBehaviour {
	GameObject enemySpyware;
	enemyHealth enemySpyHealth;

	void Awake() {
		enemySpyware = GameObject.FindGameObjectWithTag("Spyware");
		enemySpyHealth = enemySpyware.GetComponent <enemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemySpyHealth.currentHealth > 0) {
			doubleDamage();
		} else {
			return;
		}
	}

	void doubleDamage() {
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemy.GetComponent<enemyHealth>().damage = enemy.GetComponent<enemyHealth>().damage+10;
		}
	}
}
