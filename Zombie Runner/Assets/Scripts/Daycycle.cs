using UnityEngine;
using System.Collections;

public class Daycycle : MonoBehaviour {

	[Tooltip("Number of minutes per second")]
	public float timeScale;

	private Quaternion startRotation;

	// Use this for initialization
	void Start () {

	startRotation = transform.rotation;
	
	}
	
	// Update is called once per frame
	void Update () {

		float angleThisFrame = Time.deltaTime / 360 * timeScale;
		transform.RotateAround(transform.position,Vector3.forward,angleThisFrame);

	}
}
