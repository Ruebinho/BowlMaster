using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl (int pinfall) {
		try{
			rolls.Add(pinfall);
			ball.Reset();
			pinSetter.PerformAction(ActionMasterOld.NextAction(rolls));
		} catch {
			Debug.LogWarning("Gamemanager is bad!");
		}

		try{
			scoreDisplay.FillRolls(rolls);
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		} catch {
			Debug.LogWarning("ScoreDisplay sucks hard!");
		}
	}
}
