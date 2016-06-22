using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	public float standingThreshold =20f;

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
		if (Mathf.Abs(rotationInEuler.z) < standingThreshold && Mathf.Abs(rotationInEuler.x) < standingThreshold)
			return true;
		else {
			return false;
		}
	}
}
