using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	// test purpose of which room to enter
	public string destination;
	private LockManager theLockManager;
	// the index of room built
	private int roomIndex;
	// Use this for initialization
	void Start () {

	theLockManager = GetComponentInChildren<LockManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter ()
	{
		Debug.Log ("Loading A scene");
//		if (SceneManager.GetActiveScene ().name == ("Room_1")) {
//			SceneManager.LoadScene ("Start");
//		} else {
//			SceneManager.LoadScene ("Room_1");
//
//	
		if (theLockManager.isUnlocked())
			SceneManager.LoadScene (destination);
		else {

		}
	}
}

