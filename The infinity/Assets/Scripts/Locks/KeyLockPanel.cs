using UnityEngine;
using System.Collections;

public class KeyLockPanel : MonoBehaviour {


	private GameObject[] keyLockArray;
	private LockManager keyLockManager;
	// Use this for initialization
	void Start () {

	keyLockArray = GameObject.FindGameObjectsWithTag("KeyLock");

	}
	
	public void check ()
	{

		foreach (GameObject lockTosolve in keyLockArray) {
			keyLockManager = lockTosolve.GetComponent<LockManager>();
			keyLockManager.theLock.Unlock();
		}
	}
}
