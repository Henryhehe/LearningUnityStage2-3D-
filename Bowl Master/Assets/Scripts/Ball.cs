using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool inPlay = false; 

	private Rigidbody ballRigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;
	// Use this for initialization
	void Start () {
	ballRigidBody = GetComponent<Rigidbody>();
	ballRigidBody.useGravity = false;
	startPosition = GetComponent<Transform>().position;
//	Launch(ballVelocity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Launch (Vector3 velocity)
	{
	audioSource = GameObject.FindObjectOfType<AudioSource>();
	audioSource.Play();
	ballRigidBody.useGravity = true;
	ballRigidBody.velocity = velocity;
	inPlay = true;
	}
	public void reset() {
	print("pin reset");
	inPlay = false;
	ballRigidBody.useGravity = false;
	ballRigidBody.velocity = Vector3.zero;
	ballRigidBody.angularVelocity = Vector3.zero;
	ballRigidBody.position = startPosition;
	}
}
