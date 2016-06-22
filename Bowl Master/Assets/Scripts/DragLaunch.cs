using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Ball ball;
	private float dragTimeStart,dragTimeEnd;
	private float dragSpeed;
	private Vector3 dragPostionStart,dragPositionEnd;
	private bool isLaunched = false;
	private Vector3 ballPosition;
	// Use this for initialization
	void Start () {
	ball = GetComponent<Ball>();
	}	

	void Update() {

	}

	public void DragStart() {
	// Capture time and position of mouse click
	dragPostionStart= Input.mousePosition;
	dragTimeStart = Time.time;
	}
	public void DragEnd ()
	{
		dragPositionEnd = Input.mousePosition;
		dragTimeEnd = Time.time;
		float dragDuration = dragTimeEnd - dragTimeStart;
		float launchSpeedX = (dragPositionEnd.x - dragPositionEnd.x) / dragDuration;
		float launchSpeedZ = (dragPositionEnd.y - dragPostionStart.y) / dragDuration;
		Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
		// Launch the bal
		if (!isLaunched) {
			ball.Launch (launchVelocity);
			isLaunched = true;
		}	
	}
	public void MoveStart (float amount)
	{
		if (!isLaunched) {
			ball.transform.Translate(new Vector3(amount,0,0));
		}
	}
}
