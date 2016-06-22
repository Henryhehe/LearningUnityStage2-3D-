using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private float velocity = 2000;
	private Rigidbody ballRigidBody;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {

	ballRigidBody = GetComponent<Rigidbody>();
	Vector3 ballVelocity = new Vector3(0,0,velocity);
	ballRigidBody.useGravity = false;
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
	}

}
