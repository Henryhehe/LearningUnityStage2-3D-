using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text scoreText;
	public int lastStandingCount = -1;
	public GameObject pinSet;


	private bool ballEnteredBox = false;
	private float lastChangetime;
	private Ball ball;
	private Animator pinAnimator;
//	private int standingPinNum;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();	
		pinAnimator = GetComponent<Animator>();
	}
	void OnTriggerExit (Collider collider)
	{
		if (collider.gameObject.GetComponentInParent<Pin>()) {
				Destroy(collider.gameObject.transform.parent.gameObject);
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<Ball> ()) {
			scoreText.color = Color.red;
			ballEnteredBox = true;
		}
	}
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
		print(standingPinNum);
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

	void PinsHaveSettled() {
		ball.reset();
		lastStandingCount = -1; //indicate a new frame, Pins have settled and ball back 
		ballEnteredBox = false;
		scoreText.color = Color.green;
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

