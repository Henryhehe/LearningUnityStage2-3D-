using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;

public class ElectronicLockPanel : MonoBehaviour {

	public Text displayText;
	public Button[] buttonArray;
	public Button enterButton;

	private StringBuilder codeToBuild;
	private string codeBuilding;
	private string currentCode;
	private string displayInformation;
	private GameObject[] electronicLockArray;
	private LockManager electronicLockManager;
	private bool newLine = false;

	// Use this for initialization
	void Start () {

	 codeToBuild = new StringBuilder();
	 codeToBuild.Append(displayText.text);
	 electronicLockArray = GameObject.FindGameObjectsWithTag("ElectronicLock");
	 codeBuilding ="";
	 codeBuilding ="";

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!newLine) {
			codeToBuild.Append("\n");
			newLine = true;
		}	

		if (currentCode != codeBuilding) {
			currentCode = codeBuilding;
		}
		displayText.text = codeToBuild.ToString();
	}

	public void ButtonEnter(int i) {
		codeToBuild.Append(i.ToString());
		codeBuilding = codeBuilding + (i.ToString());
	}

	public void Enter() {
		codeToBuild.Append("\n");
		foreach(GameObject electronicLock in electronicLockArray) {
			electronicLockManager = electronicLock.GetComponent<LockManager>();
			if (codeBuilding.Equals (electronicLockManager.codeForElectronicLock)) {
		//this is really weird 
			electronicLockManager.theLock.Unlock();
			Debug.Log ("the code is correct");
			newLine = false;
			codeToBuild.Append("The lock is unlocked");
//TODO
//disable the screen
//			return true;
		} else {
			Debug.Log("the code is incorrect");
			newLine = false;
			codeToBuild.Append("The code doesn't seem to work");
//			return false;
		}
		codeBuilding = "";
		}
	}
}
