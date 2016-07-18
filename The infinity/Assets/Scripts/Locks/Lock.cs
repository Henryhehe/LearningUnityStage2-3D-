using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
// 	the base lock class, it will give your the basic functions of what a lock should do
//  for instance, it will give you the functions etc.
/// </summary>
public class Lock {

//
//	enum {"KeyLock","NumberLock","SafeLock","DirectionalLock"};
	public bool isUnlocked;
	public int trialNum;
	public GameObject LockScreen;
	private GameObject lockedItem;

	public Lock ()
	{
		isUnlocked = false;
		trialNum = 0;	
	}

	public virtual bool Unlock() {
		Debug.Log("the lock has been unlocked");
		isUnlocked = true;
		return true;
	}

	public virtual bool Unlock (string tryCode)
	{
		return true;
	}

	public void FailUnlock() { 
//TODO
//maybe we should play a sound or something depends on the lock?
//could be a good idea 
		Debug.Log("the lock is still locked");

	}


}
