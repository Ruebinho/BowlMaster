using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Vector3 ballStartposition;
	private Rigidbody myRigidbody;
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody>();
		myRigidbody.useGravity = false;
		audioSource = GetComponent<AudioSource>();
		ballStartposition = transform.position;
	}

	public void LaunchBall (Vector3 velocity)	{
		inPlay = true;
		myRigidbody.useGravity = true;
		myRigidbody.velocity = velocity;

		audioSource.Play ();
	}

	public void Reset() {
		inPlay = false;
		transform.position = ballStartposition;
		myRigidbody.useGravity = false;
		myRigidbody.velocity = Vector3.zero;
		myRigidbody.angularVelocity = Vector3.zero;
		transform.rotation = Quaternion.identity;
	}
}
