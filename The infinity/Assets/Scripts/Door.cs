using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter ()
	{
		Debug.Log ("Loading A scene");
		if (SceneManager.GetActiveScene ().name == ("Room_1")) {
			SceneManager.LoadScene ("Start");
		} else {
			SceneManager.LoadScene ("Room_1");

		}
	}
}

