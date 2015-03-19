using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
	public float deathTimer = 5f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, deathTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
