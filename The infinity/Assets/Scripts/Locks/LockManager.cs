using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

//the lockManager manages the behaviour of the lock, it doesn't need to know the status of the lock
//hence we instantiate a Lock object, which is inherited from the super calss Lock, and use whatever function or property that 
//object has to offer
public class LockManager : MonoBehaviour {
	
	public string key;
	public string codeForNumberLock;
	public string codeForDirectionalLock;
	public string codeForElectronicLock;
	public GameObject lockScreen;
	public GameObject menu;


	public Lock theLock;
	private string lockTag;
	private Collider playerCollider;
	// Use this for initialization
	void Start ()
	{
		lockTag = gameObject.tag; 
		switch (lockTag) {
		case "KeyLock":
			theLock = new KeyLock (key);
			break;
		case "NumberLock":
			Debug.Log ("this is a number lock, create the lock obeject susccessfully based on the tag");
			theLock = new NumberLock (codeForNumberLock);
			break;
		case "DirectionalLock":
			Debug.Log ("this is a directional lock, create the lock obeject susccessfully based on the tag");
			theLock = new DirectionalLock(codeForDirectionalLock);
			break;
		case "ElectronicLock":
			Debug.Log("this is a ElectronicLock, create the lock obeject susccessfully based on the tag");
			theLock = new ElectronicLock(codeForElectronicLock);
			break;
		default:
			Debug.Log ("This lock has been assigned a tag, a default lock is created");
			theLock = new Lock();
			break;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	// every time when it detectes a collision it will use the isUnlocked method to check whether the bool value in the Lock is true or not
	// if so. it will enbale the lock and door.. but is it doing the same thing with the door? no because it is a different object call
	// the door calls the lockManager and the lock Manager calls the Lock object
//TODO
//You can basically delete most of the codes here
	void OnTriggerEnter (Collider collider)
	{
		Debug.Log (collider.gameObject);
		Debug.Log ("somebody trying to unlock this lock?!");

		if (gameObject.tag == "NumberLock" && !theLock.isUnlocked) {
			Debug.Log ("is the numberLock panel working here");
			PanelMode (collider);
//				menu.GetComponentInChildren<NumberLockPanel>().enabled = true;
		}
//		case where it is a directional lock
		if (gameObject.tag == "DirectionalLock" && !theLock.isUnlocked) {
			Debug.Log ("is the DirectionalLock panel working here");
			PanelMode (collider);
		}
		if (gameObject.tag == "KeyLock" && !theLock.isUnlocked) {
			Debug.Log ("is the KeyLock panel working here");
			PanelMode (collider);
		}
		if (gameObject.tag == "ElectronicLock" && !theLock.isUnlocked) {
			Debug.Log ("is the ElectronicLock panel working here");
			PanelMode (collider);
		}
//		if (isUnlocked()) {
//			Debug.Log (gameObject + "you have unlocked this lock");
//		} else {
//			Debug.Log("please keep trying");
//		}
	}
// when the player leaves the door, the lock screen should be disabled
	void OnTriggerExit (Collider collider)
	{
		lockScreen.SetActive(false);
		collider.gameObject.GetComponent<FirstPersonController> ().enabled = true;
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
		lockScreen.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	void DisableMenu ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		menu.GetComponent<Canvas> ().enabled = false;
	}
// method that allows the screen to switch to lock screen mode sucessfully.
	void PanelMode(Collider collider) {
		collider.gameObject.GetComponent<FirstPersonController> ().enabled = false;
		EnableMenu ();
	}
}
