using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour{
	float x;
	float y;
	float z;
	public float speed;
	MouseLook script;
	Vector3 Value;
	void Update(){

	}
	void Start ()
	{
		GameObject player = GameObject.Find("Player");

		script = player.GetComponent<MouseLook> ();
	}
	void FixedUpdate(){
		Value = script.direction;
		print (Value);
	}
}