using UnityEngine;
using System.Collections;

//  this is the directional lock class, which of course stimulate a directional lock 
//  instead of taking in number it should be taking in a combination of directions
//  which of course is a directions strings

public class DirectionalLock : Lock {

	public string codeDirections;
	public GameObject directionalLockScreen;

	private bool isReset;

	public DirectionalLock (string code)
	{
		// we should probably stop using the magic number here 
		trialNum = 9999;
		isReset = true;
		isUnlocked = false;
		codeDirections = code;
		LockScreen = directionalLockScreen;
	}

	private void Reset ()
	{
		isReset = true;
	}

  override public bool Unlock (string code)
	{

		if (isReset && code.Equals(codeDirections)) {
			Debug.Log ("You have unlocked this directional lock");
			isUnlocked = true;
			return true;
		} else {
			Debug.Log( "Something is wrong");
			return false;
		}
	}
// do we need this method to convert things around?
	private int Translate(string code) {
		return 1;
	}
}
