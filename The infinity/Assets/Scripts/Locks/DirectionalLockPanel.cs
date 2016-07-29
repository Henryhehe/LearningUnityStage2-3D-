using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class DirectionalLockPanel : MonoBehaviour {

	private List<Transform> directionsButton;
	private Button checkButton;
	private Button resetButton;
	private string codeEnter;
	private StringBuilder codeToBuild;
	private GameObject[] DirectionLockArray;
	private LockManager directionLockManager;
	public Text informationText;
	// Use this for initialization
	void Start ()
	{
		// don't forget to initialize 
		directionsButton = new List<Transform> ();
		DirectionLockArray = GameObject.FindGameObjectsWithTag ("DirectionalLock");
		codeToBuild = new StringBuilder ();
		codeEnter = "";
		// Get the directions Button array and two buttons in the 
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "DirectionButton") {
//	Debug.Log("is this foreach get called at all?");
				directionsButton.Add (child);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InputDirections (string direction)
	{
	// Append the directions into the string builder
		Debug.Log(direction);
		codeToBuild.Append(direction);
	}
	public void Check ()
	{
		codeEnter = codeToBuild.ToString ();
		Debug.Log (codeEnter);
		foreach (GameObject directionLock in  DirectionLockArray) {
			directionLockManager = directionLock.GetComponent<LockManager> ();
	//loop to check the code	
		if (codeEnter.Equals(directionLockManager.codeForDirectionalLock)) {
			directionLockManager.theLock.Unlock();
			informationText.text = "The lock is unlocked";
	//TODO
	//disable the screen
//			return true;
																			} 
																	}
//			return false;
	}
	public void Reset()
	{
		codeToBuild = new StringBuilder ();
	}
}
