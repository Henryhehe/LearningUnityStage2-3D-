using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private bool isSpawn = false;
	public GameObject landingarePrefab;
	private Transform[] spawnPoints;
	private Vector3 respawnPosition;
	// Use this for initialization
	void Start ()
	{
		// getting the spawning positions array 
		GameObject respawnPosition = GameObject.Find ("ZombieSpawnPoints");
		spawnPoints = respawnPosition.GetComponentsInChildren<Transform> ();
//	just the print helper method to print out all the avaible positions 
//	print(spawnPoints.Length);
//	for(int i =0 ;i < spawnPoints.Length; i++) {
//		print(spawnPoints[i].transform.position);
//
//	}
		}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (isSpawn) {
			ReSpawn();
			isSpawn = false;
		}
	}

	// the reSpawn method to get player to a random selected location
	void ReSpawn ()
	{
		// get the random index 
		int index =  Random.Range(1, spawnPoints.Length - 1);
		transform.position = (spawnPoints[index].transform.position);
	}

	void OnFindClearArea() {
		Invoke ("DropFlare",3f);
	}
	void DropFlare () {
		Instantiate (landingarePrefab,transform.position,transform.rotation);
	}
}
