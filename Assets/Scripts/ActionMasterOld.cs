using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterOld {

	public enum Action {
		Tidy,
		Reset,
		EndTurn,
		EndGame
	}

	private int bowl = 1;	
	private int[] bowls = new int[21];

	public static Action NextAction(List<int> pinFalls) {
		ActionMasterOld am = new ActionMasterOld();
		Action currentAction = new Action();

		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl(pinFall);
		}

		return currentAction;
	}

	private Action Bowl (int pins) {

		if (pins > 10 || pins < 0) {
			throw new UnityException ("Ungültige Pinzahl übergeben");
		}

		bowls [bowl-1] = pins;

		if (bowl == 21) {
			return Action.EndGame;
		}

		//handles last-frame special cases
		if (bowl >= 19 && pins == 10) {
			bowl +=1;
			return Action.Reset;
		} else if (bowl == 20) {
			bowl +=1;
			if (bowls[19-1]==10 && bowls[20-1]==0) {
				return Action.Tidy;
			} else if (bowls[19-1] + bowls[20-1]==10) {
				return Action.Reset;
			} else if (Bowl21Awarded()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}

		if (bowl >= 19 && Bowl21Awarded() && (bowls[19] <10)) {
			bowl +=1;
			return Action.Tidy;
		} else if (bowl >= 19 && Bowl21Awarded()) {
			bowl +=1;
			return Action.Reset;
		} else if (bowl == 20 && !Bowl21Awarded()) {
			return Action.EndGame;
		}

		if (bowl % 2 != 0) { // first bowl of frame
			if (pins == 10) {
				bowl +=2;
				return Action.EndTurn;
			} else {
			bowl +=1;
			return Action.Tidy;
			}
		} else if (bowl % 2 == 0) { // second bowl of frame
			bowl +=1;
			return Action.EndTurn;
		}

//	other behaviour

	throw new UnityException ("Es wurde Scheiße übergeben!");
	}

	public bool Bowl21Awarded() {
		//Remember that arrays start counting at 0

		return (bowls[19-1] + bowls[20-1] >= 10);
	}
}
