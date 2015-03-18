using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {
	enemyHealth enemyHealth;
	GameObject start;
	GameObject player;
	playerShooting shot;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		shot = player.GetComponentInChildren<playerShooting> ();
		start = GameObject.FindGameObjectWithTag ("StartButton");
		enemyHealth = start.GetComponent<enemyHealth> ();
	}

	// Update is called once per frame
	void Update () {
		if (enemyHealth.currentHealth <= shot.damagePerShot) {
			Application.LoadLevel ("Virusdotexe");
		}
	}
}
