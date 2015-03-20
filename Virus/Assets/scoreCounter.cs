using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreCounter : MonoBehaviour {
	
	public static int frameCount;
	public static int scoreCount;
	Text text;
	
	void Awake() {
		DontDestroyOnLoad (text);
		text = GetComponent<Text> ();
		frameCount = 0;
		scoreCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		frameCount++;
		scoreCount = frameCount / 60;
		text.text = "Score: " + scoreCount;
	}
}