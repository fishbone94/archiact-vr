using UnityEngine;
using System.Collections;

public class PlasmaShield : MonoBehaviour {
	GameObject defender;
	GameObject enemy;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		defender = GameObject.FindGameObjectWithTag ("WindowsDefenderFront");
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy" && defender!= null) {
			col.gameObject.GetComponent<enemyHealth>().damage -= col.gameObject.GetComponent<enemyHealth>().halfLife;
		}

	}
}
