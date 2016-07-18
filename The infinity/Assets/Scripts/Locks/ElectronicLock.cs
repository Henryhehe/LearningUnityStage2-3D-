using UnityEngine;
using System.Collections;

public class ElectronicLock : Lock {

	public int electronicLockTrialNum;
	public string codeString;
	public GameObject ElectronicLockScreen;

	// lock out time which disable the lock for the player 

	private int lockOutSeconds;

	public ElectronicLock() {

		trialNum = electronicLockTrialNum;
		LockScreen = ElectronicLockScreen;
	}

	private void LockOut() {


	}

}
