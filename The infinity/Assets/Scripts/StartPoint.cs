using UnityEngine;
using System.Collections;

public class StartPoint : MonoBehaviour {

	private GameObject actualPlayer;
	// Use this for initialization
	void Start ()
	{
		// set the player's position to where is should be 
		if (GameObject.Find ("Player")) {
			actualPlayer = GameObject.Find ("Player");
			actualPlayer.transform.Translate(transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
