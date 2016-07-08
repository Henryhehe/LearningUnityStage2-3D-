using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

	public GameObject player;
	public GameObject startPoint;

	// Use this for initialization
	void Start ()
	{
		if (!GameObject.Find ("Player")) {
			Debug.Log ("trying to create a player");
			Instantiate (player, transform.position, Quaternion.identity);
		} else {
			GameObject actualPlayer = GameObject.Find ("Player");
			if(GameObject.Find ("MusicPlayer")) print("we have a music player");
			GameObject musicPlayer = GameObject.Find ("MusicPlayer");
			Object.DontDestroyOnLoad(actualPlayer);
			Object.DontDestroyOnLoad(musicPlayer);
			}
		}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
