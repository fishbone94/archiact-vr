using UnityEngine;
using System.Collections;

public class FirewallTrigger : MonoBehaviour {
	//Make 1-shotable
	//When dead, run Activate();

	bool dead = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
				if (dead != false) {
						Activate ();
				}
		}
	void Activate(){
		GameObject Firewall = Instantiate(Resources.Load("Firewall", typeof(GameObject))) as GameObject;
		Instantiate(Firewall, new Vector3(0, 10, -15), Quaternion.Euler(0,0,0));
	}
	
}
