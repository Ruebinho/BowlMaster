using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest
{	
	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void Setup() {
		pinFalls = new List<int>();
	}

	[Test]
	public void T00PassingTest()
	{
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurnTest()
	{	
		pinFalls.Add(10);
		Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02NineBowledReturnsTidyTest()
	{	
		pinFalls.Add(9);
		Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
	}

//	[Test]
//	public void T03InvalidPinsMinus1()
//	{	
//		Assert.AreEqual(1, actionMaster.Bowl(-1));
//	}
//
//	[Test]
//	public void T04InvalidPinsOver10()
//	{	
//		Assert.AreEqual(2, actionMaster.Bowl(11));
//	}

	[Test]
	public void T05Bowl28ReturnsEndTurn()
	{	
		int[] rolls = {8,2};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06CheckResetAtStrikeInLastFrame()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07CheckResetAtSpareInLastFrame()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09CheckEndGameAfterLastFrame()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 8,2, 9};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10EndGameAfterBowl20()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 8,1};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11TidyAfterStrikeBowl19AndNotAllPinsBowl20()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11TidyAfterStrikeBowl19AndNoPinBowl20()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12StrikeInSecondBowlofFrame()
	{	
		int[] rolls = {0,10, 5,1};
		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T1310thFrameTurkey()
	{	
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
	}
}