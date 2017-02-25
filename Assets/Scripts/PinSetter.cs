using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	private Animator animator;
	private PinCounter pinCounter;

	private ActionMasterOld actionMaster = new ActionMasterOld(); // we need it here because we only need one instance

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RaisePinsIfStanding() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
				pin.RaiseIfStanding();
			}
	}

	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
				pin.Lower();
			}
	}

	public void RenewPins() {
		Instantiate(pinSet);
		pinSet.transform.position += new Vector3(0,20,0);
	}

	public void PerformAction(ActionMasterOld.Action action){
		if (action == ActionMasterOld.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMasterOld.Action.Reset) {
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMasterOld.Action.EndTurn) {
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMasterOld.Action.EndGame) {
			throw new UnityException("Don't know how to handle EndGame!");
		}
	}

	void OnTriggerExit(Collider collider) {
		GameObject thingLeft = collider.gameObject;

		if (thingLeft.GetComponent<Pin>()){
			Destroy(thingLeft);
		}
	}
}
