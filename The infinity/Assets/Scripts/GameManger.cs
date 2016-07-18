using UnityEngine;
using System.Collections;

public class GameManger : MonoBehaviour {

	public GameObject player;
	public GameObject startPoint;
	private GameObject actualPlayer;
	private int cheatFlag = 1;
	// Use this for initialization
	void Start ()
	{
//			Object.DontDestroyOnLoad(gameObject); does it work for the gameManager itself? probably not then?
		if (!GameObject.Find ("Player")) {
			Debug.Log ("trying to create a player");
			Instantiate (player, transform.position, Quaternion.identity);
		} else {
	// Make sure to keep the music player and player to the next scene 
			actualPlayer = GameObject.Find ("Player");
			Debug.Log(startPoint.transform);
			if(GameObject.Find ("MusicPlayer")) print("we have a music player");
			GameObject musicPlayer = GameObject.Find ("MusicPlayer");
			Object.DontDestroyOnLoad(actualPlayer);
			Object.DontDestroyOnLoad(musicPlayer);
			actualPlayer.transform.Translate(transform.position);
			}
		}
	
	
	// Update is called once per frame
	void Update ()
	{
		if (actualPlayer.transform.position != startPoint.transform.position && (cheatFlag%2 != 0)) {
			actualPlayer.transform.position = startPoint.transform.position;
			Debug.Log("is this method got called at all?");
			cheatFlag ++;
		}
	
	}
}
