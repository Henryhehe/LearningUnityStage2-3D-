using UnityEngine;
using System.Collections;

public class KeyLock : Lock {

	// right now for the test purpose most of the attributes are public
	// in the future it will all be changed to private that we are able to protect it.
	public string TherightKey;
	public  GameObject KeyLockScreen;
	
	public KeyLock(string rightKey) {
		// becasue it is a key lock hence it has infinite trial number 
		trialNum = 9999;
		TherightKey = rightKey;
		LockScreen = KeyLockScreen;
		isUnlocked = false;

	}

	override public bool Unlock ()
	{
//TODO 
//needs to find in the backpack or item system.
		foreach (JsonTest2.Staff staffToFind in JsonTest2.ItemList) {
			if (staffToFind.slug == TherightKey) {
				Debug.Log("this is the keyLock class and you have find the Test key");
				isUnlocked = true;
				return true;
			}
		}
			Debug.Log("this is the keyLock class and did npt have the right key with you");
			return false;
	}
}
