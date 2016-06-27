using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	public bool ballEnteredBox = false;
	private Ball ball;
	private Animator pinAnimator;
	private PinCounter pinCounter;
	private float lastChangetime;
//	private int lastSettleCount = 10;
//	private int lastStandingCount = -1;
//	private int standingPinNum;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();	
		pinAnimator = GetComponent<Animator>();	
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	// I think this method is to destroy the pins when it lefe the collider.. but well doesn't seem very necessary now 
	void OnTriggerExit (Collider collider)
	{
		if (collider.gameObject.GetComponentInParent<Pin>()) {
				Destroy(collider.gameObject.transform.parent.gameObject);
		}

	}

//	void OnTriggerEnter (Collider other)
//	{
//		if (other.gameObject.GetComponent<Ball> ()) {
//			scoreText.color = Color.red;
//			ballEnteredBox = true;
//		}
//	}
//

	// Update is called once per frame
//	void Update ()
//	{
//		if (ballEnteredBox) {
//			pinCounter.GetPinsNum();
////			PerformAction();
//			ball.reset();
//		}
//	}

//	int CountStanding ()
//	{
//		int standingPinNum = 0;
//		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
//			if (pin.IsStanding ())
//				standingPinNum++;
//		}
//		return standingPinNum;
//	}
//	void UpdateStandingCountAndSettle ()
//	{
//		// update the lastStandingCount
//		//call pinsHaveSettled
//		//has the count change? if not 
//		int currentStanding = CountStanding ();
//		if (currentStanding != lastStandingCount) {
//			lastChangetime = Time.time;
//			lastStandingCount = currentStanding;
//			return;
//		}
//		float settledTime = 3f; // how long to wait 
//		if ((Time.time - lastChangetime) > settledTime) {
//			PinsHaveSettled();
//		}
//	}
//


	public void PerformAction( ActionMasterOld.Action action)
	{

		if (action == ActionMasterOld.Action.Tidy) {
			pinAnimator.SetTrigger("tidyTrigger");
		} else if (action == ActionMasterOld.Action.EndTurn) {
			pinAnimator.SetTrigger("resetTrigger");	
			pinCounter.Reset();
		} else if (action == ActionMasterOld.Action.Reset) {
			pinAnimator.SetTrigger("resetTrigger");	
			pinCounter.Reset();
		} else if (action == ActionMasterOld.Action.EndGame) {
			throw new UnityException("not sure how to handle endgame");
		}
		; //indicate a new frame, Pins have settled and ball back 
		ballEnteredBox = false;
	}

	// a bunch a stupid triggers method.
	public void ResetTrigger() {
	pinAnimator.SetTrigger("resetTrigger");	
	}

	public void TidyTrigger() {
	pinAnimator.SetTrigger("tidyTrigger");
	}
	public void RaisePins ()
	{
		// raise standing pins only by the distance to raise 
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Raise ();
		}	
	}
	public void LowerPins ()
	{		
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	//lower pins only by the distance to low 
	}
	public void RenewPins() {
		print("Pins renew");
		Instantiate (pinSet,new Vector3(0,20,1829),Quaternion.identity);
	}
	// TO HELP CONTROL THE 
}

