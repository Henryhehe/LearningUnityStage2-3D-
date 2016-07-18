using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
public class NumberLockPanel : MonoBehaviour {

	public GameObject[] displayTextArray;
	public Text informationText;
	public Button checkButton;


	private string correctCode;
	private string codeEnter;
	private GameObject[] numberLockArray;
	private StringBuilder codeToBuild;
	private LockManager numLockManager;
	// Use this for initialization

	void Start ()
	{
// I think the order is taken backwards? so why is that, any reason?
//		displayTextArray = GameObject.FindGameObjectsWithTag("NumberLockDigits");
// so may just as well use an easy way out by dragging the staff into ut 
	codeToBuild = new StringBuilder();
	// just to text if the check method work
	numberLockArray = GameObject.FindGameObjectsWithTag("NumberLock");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// check to see if the code is correct 

// not sure if I should put the methods here, or just in a seprate button class
	public void UpNum(Text text) {
	int currentValue = int.Parse(text.text);
	string displayText;
	currentValue = (currentValue +1) %10;
	displayText = currentValue.ToString();
	text.text = displayText;
	}

	public void DownNum (Text text)
	{
		int currentValue = int.Parse (text.text);
		string displayText;
		if (currentValue - 1 >= 0) {
			currentValue = (currentValue - 1) % 10;
			displayText = currentValue.ToString ();
			text.text = displayText;
		}
	}
	public void Check ()
	{
		codeToBuild = new StringBuilder();
// using String Builder to get the cide 
		foreach (GameObject text in displayTextArray) {
			codeToBuild.Append (text.GetComponent<Text> ().text);
		}	
		codeEnter = codeToBuild.ToString ();
		foreach(GameObject numLock in numberLockArray) {
			numLockManager = numLock.GetComponent<LockManager>();
		if (codeEnter.Equals (numLockManager.codeForNumberLock)) {
		//this is really weird 
			numLockManager.theLock.Unlock();
			Debug.Log ("the code is correct");
			informationText.text = "The lock is unlocked";
//TODO
//disable the screen
//			return true;
		} else {
			Debug.Log("the code is incorrect");
			informationText.text = "The code doesn't seem to work";
//			return false;
		}
		codeEnter = "";
		}
	}

	// setter method for a number lock to set the correct code
	public void setCorrectCode(string code) {
	correctCode = code;
	}

}
