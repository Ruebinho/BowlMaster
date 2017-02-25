using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z <= 1829f) {
			transform.position = ball.transform.position - offset;
		}
	}
}
