using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text scoreText;
//	private int standingPinNum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = CountStanding().ToString();
	}

	int CountStanding ()
	{
		int standingPinNum = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()) {
		if(pin.IsStanding())
			standingPinNum++;
		}
		print(standingPinNum);
		return standingPinNum;
	}
}
