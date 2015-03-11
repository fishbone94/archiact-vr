using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {
	public Transform target;
	public int moveSpeed = 3;
	public int rotationSpeed = 3;
	public float range = 1000f;
	public float range2 = 1000f;
	public float stop = 0f;
	Transform myTransform;

	void Awake() {
		myTransform = transform;
	}

	void Start() {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update() {
		float distance = Vector3.Distance (myTransform.position, target.position);

		if (distance <= range2 && distance >= range) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		} else if (distance <= range && distance > stop) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed*Time.deltaTime);
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
		} else if (distance <= stop) {
			myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed*Time.deltaTime);
		}
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.name == "First Person Controller") {
			Destroy(gameObject);
		}
	}
}
