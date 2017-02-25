using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {
	
	public float standingThreshold = 3f;
	public float distanceToRaise = 40f;

	private float startingYPos;
	private Rigidbody rigidbody;
				
	// Use this for initialization
	void Start () {
		startingYPos = transform.position.y;
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RaiseIfStanding() {
		if (IsStanding()) {
				rigidbody.useGravity = false;
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				transform.Translate(new Vector3(0,distanceToRaise,0), Space.World);
				transform.rotation = Quaternion.Euler(270f, 0, 0);
				}
	}

	public void Lower() {
			transform.Translate(new Vector3(0,-distanceToRaise,0), Space.World);
			rigidbody.useGravity = true;
	}

	public bool IsStanding() {

		if (gameObject!= null) {
			if ((transform.position.y - standingThreshold) > startingYPos) {
				return false;
			} else {
				return true;
			}
		}
	return false;
	}


}
