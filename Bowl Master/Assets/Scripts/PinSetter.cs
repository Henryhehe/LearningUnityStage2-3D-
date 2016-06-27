using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text scoreText;

	public GameObject pinSet;
	public bool ballEnteredBox = false;


	private Ball ball;
	private Animator pinAnimator;
	private ActionMaster actionMaster;
	private float lastChangetime;
	private int lastSettleCount = 10;
	private int lastStandingCount = -1;
//	private int standingPinNum;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();	
		pinAnimator = GetComponent<Animator>();
		actionMaster = new ActionMaster();
	}
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
	void Update ()
	{
		scoreText.text = CountStanding ().ToString ();
		if (ballEnteredBox) {
			UpdateStandingCountAndSettle();
		}
	}

	int CountStanding ()
	{
		int standingPinNum = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ())
				standingPinNum++;
		}
		return standingPinNum;
	}

	void UpdateStandingCountAndSettle ()
	{
		// update the lastStandingCount
		//call pinsHaveSettled
		//has the count change? if not 
		int currentStanding = CountStanding ();
		if (currentStanding != lastStandingCount) {
			lastChangetime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settledTime = 3f; // how long to wait 
		if ((Time.time - lastChangetime) > settledTime) {
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled ()
	{
		int standing = CountStanding();
		int pinFall = lastSettleCount - standing; 
		lastSettleCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log("pinFall is" + pinFall +" " +  action);

		if (action == ActionMaster.Action.Tidy) {
			pinAnimator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			pinAnimator.SetTrigger("resetTrigger");	
			lastSettleCount = 10;
		} else if (action == ActionMaster.Action.Reset) {
			lastSettleCount = 10;
			pinAnimator.SetTrigger("resetTrigger");	
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException("not sure how to handle endgame");
		}

		ball.reset();
		lastStandingCount = -1; //indicate a new frame, Pins have settled and ball back 
		ballEnteredBox = false;
		scoreText.color = Color.green;
	}

	void SetAnimator ()
	{

	}

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
			transform.rotation = Quaternion.Euler(new Vector3(0,0,0));

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

}

