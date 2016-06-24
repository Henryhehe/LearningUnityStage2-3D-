using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	public float standingThreshold =30f;
	private float distanceToRaise = 100f;

	// Use this for initialization
	void Start () {

//	print(name);
	}

	void Update() {

//	if(IsStanding())
//		print("true");
//		else 
//		print("false");
//
	}
	public bool IsStanding ()
	{
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float z = Mathf.Abs(rotationInEuler.z);
		float x = Mathf.Abs(rotationInEuler.x);
		if ((z < standingThreshold || (360 - z) < standingThreshold) && (x < standingThreshold || (360 - x) < standingThreshold))
			return true;
		else {
			return false;
		}
	}
	public void Raise ()
	{
		// raise standing pins only by the distance to raise 
		if (IsStanding()) {
			transform.Translate (Vector3.up * distanceToRaise, Space.World);
			GetComponent<Rigidbody> ().useGravity = false;
		}	
	}
	public void Lower() {		
			transform.Translate(Vector3.down * distanceToRaise,Space.World);
			GetComponent<Rigidbody>().useGravity = true;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
	//lower pins only by the distance to low 
	}

}
