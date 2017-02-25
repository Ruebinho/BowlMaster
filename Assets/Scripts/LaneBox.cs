using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour {

	private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
		pinSetter = FindObjectOfType<PinSetter>();
	}
}
