using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest{

	private List<int> pinFalls;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	[SetUp]
	public void SetUp() {
	// this will run before everytest is run 
	pinFalls = new List<int>();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual(1,1);
	}
	[Test]
	public void T01OneStrikeReturnsEndTurn(){
		pinFalls.Add(10);
		Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
	}
//	[Test]
//	public void T02Bowl8ReturnsTidy() {
//		Assert.AreEqual(tidy,actionMaster.Bowl(8));
//	}
//	[Test]
//	public void T03BowlReturnReset() {
//		Assert.AreEqual(reset,actionMaster.isReset());
//	}
//	[Test]
//	public void T04Bowl28SpareReturnsEndTurn() {
//		Assert.AreEqual(tidy,actionMaster.Bowl(8));
//		Assert.AreEqual(endTurn,actionMaster.Bowl(2));
//	}
//	[Test]
//	public void T05CheckResetAtStrikeInLastFrame() {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(reset,actionMaster.Bowl(10));
//	}
//	[Test]
//	public void T06CheckResetAtStrikeInLastFrame() {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		actionMaster.Bowl(1);
//		Assert.AreEqual(reset,actionMaster.Bowl(9));
//	}
//	[Test]
//	public void T07YouTubeRollsEndGame() {
//		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(endGame,actionMaster.Bowl(9));
//	}
//	[Test]
//	public void T08GameEndsAtBowl20() {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,1};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(endGame,actionMaster.Bowl(1));
//	}
//	[Test]
//	public void T09TidyAfterBowl19Strike() {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(tidy,actionMaster.Bowl(5));
//	}
//	[Test]
//	public void T10BowlIndexTest() {
//		int[] rolls = {0,10, 5};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(endTurn,actionMaster.Bowl(1));
//	}
//	[Test]
//	public void T11Frame10th() {
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
//		foreach(int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//		Assert.AreEqual(reset,actionMaster.Bowl(10));
//		Assert.AreEqual(reset,actionMaster.Bowl(10));
//		Assert.AreEqual(endGame,actionMaster.Bowl(10));
//	}

}
