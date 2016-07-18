using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

//the lockManager manages the behaviour of the lock, it doesn't need to know the status of the lock
//hence we instantiate a Lock object, which is inherited from the super calss Lock, and use whatever function or property that 
//object has to offer
public class LockManager : MonoBehaviour {
	
	public GameObject key;
	public string codeForNumberLock;
	public GameObject lockScreen;
	public GameObject menu;


	public Lock theLock;

	// Use this for initialization
	void Start ()
	{
		if (gameObject.tag == "KeyLock") {
			// for the test purpose, this is the key lock test. 
//			Debug.Log ("this is a KeyLock,create the Lock Object sucessfully based on the tag");
			theLock = new KeyLock (key);
//			print (theLock.trialNum);
		}
		if (gameObject.tag == "NumberLock") {
			Debug.Log ("this is a number lock, create the lock obeject susccessfully based on the tag");
			theLock = new NumberLock(codeForNumberLock);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	// every time when it detectes a collision it will use the isUnlocked method to check whether the bool value in the Lock is true or not
	// if so. it will enbale the lock and door.. but is it doing the same thing with the door? no because it is a different object call
	// the door calls the lockManager and the lock Manager calls the Lock object
	void OnTriggerEnter (Collider collider)
	{
		Debug.Log ("somebody trying to unlock this lock?!");
		if (gameObject.tag == "NumberLock") {
				Debug.Log("is thue numberLock panel working here");
				collider.GetComponent<FirstPersonController>().enabled = false;
				EnableMenu();
//				menu.GetComponentInChildren<NumberLockPanel>().enabled = true;
		}
//		if (isUnlocked()) {
//			Debug.Log (gameObject + "you have unlocked this lock");
//		} else {
//			Debug.Log("please keep trying");
//		}

	}

//	void OnTriggerExit (Collider collider)
//	{
//		if(collider.tag == "Player")
//		DisableMenu();
//	}
	// the method is check if the lock is unlocked by calling the lock object b
	public bool isUnlocked ()
	{
		if (theLock.isUnlocked){
			return true;
		} else {
			theLock.FailUnlock ();
			return false;
		}
}
// help method to help with enabling and disabling the screen.
	void EnableMenu ()
	{
		menu.GetComponent<Canvas> ().enabled = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	void DisableMenu ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		menu.GetComponent<Canvas> ().enabled = false;
	}

}
