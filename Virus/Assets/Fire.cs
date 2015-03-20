using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	GameObject fire;
	enemyHealth enemyHealth;
	public int fireDamage = 15;
	bool touch;
	BoxCollider boxCollider;
	float timer = 0.1f;
	public float deathTimer = 6f;
	
	// Use this for initialization
	void Awake() {
		//find 
		fire = GameObject.FindGameObjectWithTag ("Firewall");
		boxCollider = GetComponent<BoxCollider> ();
	}
	
	void Start() {
		Destroy (gameObject, deathTimer);	
	}
	
	// Update is called once per frame
	void Update () {
		if (touch) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			timer = 0.1f;
			boxCollider.isTrigger = false;
			touch = false;
		}
		if (timer > 0 && touch == true) {
			boxCollider.isTrigger = true;
		}
	}
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<enemyHealth>().TakeDamage(fireDamage, fire.transform.position);
		}
		if (col.gameObject.tag == "Worm") {
			col.gameObject.GetComponent<enemyHealth>().TakeDamage(fireDamage, fire.transform.position);
		}
		if (col.gameObject.tag != "Enemy" || col.gameObject.tag != "Worm" && timer == 0.1f) {
			touch = true;
		}
	}
}
