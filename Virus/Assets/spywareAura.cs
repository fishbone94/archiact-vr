using UnityEngine;
using System.Collections;

public class spywareAura : MonoBehaviour {
	GameObject player;
	playerShooting playerShooting;

	GameObject enemy;
	enemyHealth enemyHealth;
	
	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerShooting = player.GetComponentInChildren<playerShooting> ();
	}
	
	void Update () {
		enemy = GameObject.FindGameObjectWithTag("Spyware");
		enemyHealth = enemy.GetComponent <enemyHealth> ();
		if(enemyHealth) {
			aura();
		}
		if (enemyHealth.currentHealth <= 5){
			playerShooting.damagePerShot = 20;
		}
	}

	void aura() {
		if (playerShooting.damagePerShot == 20) {
			playerShooting.damagePerShot = playerShooting.damagePerShot/2;
		}
	}
}
