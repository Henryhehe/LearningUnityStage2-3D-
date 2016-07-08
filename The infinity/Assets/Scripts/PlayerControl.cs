using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private Camera eyes;
	private float defaultFov;
	// Use this for initialization
	void Start () {
	eyes = GetComponentInChildren<Camera>();
	defaultFov = eyes.fieldOfView;
	}
	// Update is called once per frame
	void Update () {
		// if the button has been pressed, the FOV would be half 
		if (Input.GetButtonDown ("Focus")) {
			print ("v has been pressed");
			eyes.fieldOfView = defaultFov / 2.0f;
		}
		// if the button has been realeased,the FOV would be reset to default 
		if (Input.GetButtonUp ("Focus")) {
			eyes.fieldOfView = defaultFov;
		}
	}
}
