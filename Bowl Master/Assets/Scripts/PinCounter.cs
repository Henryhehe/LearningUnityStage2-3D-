using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

		public Text scoreText;
		public bool ballEnteredBox = false;

		private GameManager gameManager;
		private bool ballOutOfPlay = false;
		private int lastStandingCount = -1;
		private float lastChangetime;
		private int lastSettleCount = 10;
	// this method is to count how many Pins are still standing, hence to know how many pins have been knocked down
	// but when and where to call this method.


	void Start ()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	void Update ()
	{
		scoreText.text = CountStanding ().ToString ();
		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle();
			scoreText.color = Color.red;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}

	}
	int CountStanding ()
	{
		int standingPinNum = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ())
				standingPinNum++;}
		return standingPinNum;
		}
	private void UpdateStandingCountAndSettle ()
	{

		int currentStanding = CountStanding ();
		if (currentStanding != lastStandingCount) {
			lastChangetime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settledTime = 3f; // how long to wait
		if ((Time.time - lastChangetime) > settledTime) {
		 	PinsSettled();
		}
	}

	private void PinsSettled()
	{

		int standing = CountStanding();
		int pinFall = lastSettleCount - standing; 
		lastSettleCount = standing;
		gameManager.Bowl(pinFall);
		lastStandingCount = -1;
		ballOutOfPlay = false;
		scoreText.color = Color.green;
	}

	public void Reset()
	{
		lastSettleCount = 10;
	}

}
