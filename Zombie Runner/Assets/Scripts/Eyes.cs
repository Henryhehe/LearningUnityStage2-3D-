using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	private Camera eyes;
	private float defaultFov;
	// Use this for initialization
	void Start () {
	eyes = GetComponent<Camera>();
	defaultFov = eyes.fieldOfView;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if the button has been pressed, the FOV would be half 
		if (Input.GetButtonDown ("Zoom")) {
			print ("v has been pressed");
			eyes.fieldOfView = defaultFov / 2.0f;
		}
		// if the button has been realeased,the FOV would be reset to default 
		if (Input.GetButtonUp ("Zoom")) {
			eyes.fieldOfView = defaultFov;
		}
	}
}
