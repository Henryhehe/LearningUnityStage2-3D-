using UnityEngine;
using System.Collections;

public class ElectronicLock : Lock {

	public int electronicLockTrialNum;
	public string codeString;
	public GameObject ElectronicLockScreen;

	// lock out time which disable the lock for the player 

	private int lockOutSeconds;

	public ElectronicLock(string codeForElectronicLock) {

		codeString = codeForElectronicLock;
		trialNum = electronicLockTrialNum;
		LockScreen = ElectronicLockScreen;
	}

	private void LockOut() {


	}

}
