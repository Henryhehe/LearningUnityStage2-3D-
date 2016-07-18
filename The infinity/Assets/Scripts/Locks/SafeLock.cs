using UnityEngine;
using System.Collections;

// this is the safeLock class, which is probably like ElectronicLock 
// I think the only difference is probably the beeing part

public class SafeLock : Lock {

	private AudioClip warningSound; 
	public GameObject safeLockScreen;

	public SafeLock() {

	LockScreen = safeLockScreen;
	}

//TODO
//make sure the safe would play the warning sound when the wrong code has been enter for too many times
	private void errorWarning() {
			
	}

}
