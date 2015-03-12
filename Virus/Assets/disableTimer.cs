using UnityEngine;
using System.Collections;

public class disableTimer : MonoBehaviour {

	public float timer = 5f;
	public bool disabled;

	void Awake() {
		disabled = false;
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Trojan(Clone)") {
			disabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if (disabled) {
			timer -= Time.deltaTime;
		}
		if (timer <= 0) {
			timer = 5f;
			disabled = false;
		}
	}
}
