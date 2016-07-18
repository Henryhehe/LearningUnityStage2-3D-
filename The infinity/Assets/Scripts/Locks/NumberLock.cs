using UnityEngine;
using System.Collections;


// this is the numberLock class which usually has a set length of code and infinite trying time 
// which also requires button for player to adjust the number

public class NumberLock : Lock {

	private int codeLength; 
	private string NumberLockCode;
	private NumberLockPanel NumberLockScreen;

	public NumberLock (string theCode)
	{
		// magic number 
		isUnlocked = false;
		trialNum = 9999;
		NumberLockCode = theCode;
	}
//TODO writeout the UI panel for this lock.
//
//	override public bool Unlock (string tryCode)
//	{
//		if (tryCode.Equals (NumberLockCode)) {
//			return true;
//		} else {
//			Debug.Log ("the code to numberLock is not correct");
//			return false;
//		}
//}

}
