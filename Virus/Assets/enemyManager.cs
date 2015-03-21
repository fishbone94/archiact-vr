using UnityEngine;

public class enemyManager : MonoBehaviour
{
	public GameObject[] enemy; 
	public float spawnStartTimer = 3f;
	public float spawnTime;          
	public Transform[] spawnPoints;
	public float level = 2;
	
	
	void Awake() {
		spawnTime = spawnStartTimer;
	}
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);
		InvokeRepeating ("levelCounter", 0f, 30f);
	}
	
	void Update() {
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0f) {
			Spawn();
			spawnTime = spawnStartTimer;
		}
	}
	
	void levelCounter() {
		level += 1.005f;
		spawnStartTimer = (1-(level*0.1f))*spawnStartTimer;
	}
	
	void Spawn ()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player.GetComponent<playerHealth>().isDead == true) {
			// If the player has no health left...
			// ... exit the function.
			return;
		}
		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		
		int powerUpIndex = Random.Range (0, enemy.Length);
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy[powerUpIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}