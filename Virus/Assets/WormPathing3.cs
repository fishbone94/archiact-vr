using UnityEngine;
using System.Collections;

public class WormPathing3 : MonoBehaviour {
	public Transform Target; 
	public float MoveSpeed; 
	public float RotationSpeed = 3f;
	
	private Transform _myTransform;
	private float upDown;
	private int speed = 2;
	private int hightDiv = 150;
	private float t;
	
	void Awake()
	{
		_myTransform = transform;
	}
	
	void Start()
	{
		Target = GameObject.FindWithTag("Player").transform;
	}
	
	void Update()
	{
		_myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, Quaternion.LookRotation(Target.position - _myTransform.position), RotationSpeed * Time.deltaTime);
		_myTransform.position += _myTransform.forward*MoveSpeed*Time.deltaTime;
		transform.Translate(Vector3.left * 5 * upDown); 
		t += speed*(Time.deltaTime); 
		upDown = (Mathf.Sin(t))/hightDiv;
	}
}