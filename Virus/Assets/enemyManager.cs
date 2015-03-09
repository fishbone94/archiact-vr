using UnityEngine;

public class enemyManager : MonoBehaviour
{
	public GameObject enemy;                
	public float spawnTime = 3f;            
	public Transform[] spawnPoints;
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
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
		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}