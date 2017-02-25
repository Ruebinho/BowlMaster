using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () {
		int[] rolls = {1};
		string rollsString = "1";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02Bowl11 () {
		int[] rolls = {1,1};
		string rollsString = "11";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03BowlStrike () {
		int[] rolls = {10};
		string rollsString = "X ";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04BowlStrike1 () {
		int[] rolls = {10,1};
		string rollsString = "X 1";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05BowlSpareInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,3};
		string rollsString = "1111111111111111111/3";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06BowlStrikeInLastFrame() {
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
		string rollsString = "111111111111111111X11";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07BowlGutter() {
		int[] rolls = {0};
		string rollsString = "-";

		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
