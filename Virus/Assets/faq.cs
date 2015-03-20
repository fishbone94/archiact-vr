using UnityEngine;
using System.Collections;

public class faq : MonoBehaviour {
	enemyHealth enemyHealth;
	GameObject start;
	GameObject player;
	playerShooting shot;

	void Awake() {
		player = GameObject.FindGameObjectWithTag ("Player");
		shot = player.GetComponentInChildren<playerShooting> ();
		start = GameObject.FindGameObjectWithTag ("FAQButton");
		enemyHealth = start.GetComponent<enemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth.currentHealth <= shot.damagePerShot) {
			Application.LoadLevel ("FAQdotexe");
		}
	}
}
