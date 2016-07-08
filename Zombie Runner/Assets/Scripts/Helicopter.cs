using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

	private bool called = false;
	public AudioClip callSound ;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame

	void OnDispatchHelicopter ()
	{
		Debug.Log("Helicopter called");
		rigidBody.velocity = new Vector3(0,0,100f);
		called = true;
	}
}
