using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMasterOld{

	public enum Action {Tidy,Reset,EndTurn,EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;
	private List<int> pinFalls = new List<int>();


	public static Action NextAction(List<int> pinFallsFromGameManager)
	{ 
		ActionMasterOld action = new ActionMasterOld ();
		Action currentAction = new Action();
		// the reson doing this is that.. when it loops through all the pins, the last one left
		// would just be the action that needs to be taken 
		// which is super strange, because it seems such a waste a runtime and 
		// there must be some other ways of doing it for sure..for sure.
		foreach (int pins in pinFallsFromGameManager) {
				 currentAction = action.Bowl (pins);
			}
		return currentAction;
	}

	public Action Bowl (int pins)
	{ //TODO make private
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invaild Pin Count");
		}
		// just adding the score array
		bowls [bowl - 1] = pins;
		pinFalls.Add(pins);
		// end game condition 
		if (bowl == 21) {
			return Action.EndGame;
		}
		// Handle last frame special case

		if (bowl >= 19 && pins == 10) {
			bowl++;
			return Action.Reset;
		} else if (bowl == 20) {
			bowl++;
			if (bowls [19 - 1] == 10 && bowls [20 - 1] == 0) {
				return Action.Tidy;
			} else if (bowls [19 - 1] + bowls [20 - 1] == 10) {
				return Action.Reset;
			} else if (Bowl21Awarded ()) {
				return Action.Tidy;
			} else {
				return Action.EndGame;
			}
		}
		// if first bowl of frame
		// return Action.Tidy
		if (bowl % 2 != 0) { // first bowl of frames 1-9
			if (pins == 10) {
				bowl +=2;
				return Action.EndTurn;
			}
			bowl += 1;
			return Action.Tidy;
		} else if (bowl % 2 == 0) {// second bowl of frames 1-9
			bowl +=1;
			return Action.EndTurn;
		}
		throw new UnityException (" Not sure what action to return!");
	}


	// you know what it is about 21 awarded? just some strange rules that I don't quite care about :(
	private bool Bowl21Awarded() {
		// based on the rule the bowl 21 is the one being awarded 
		return((bowls[19-1] + bowls[20-1]) >= 10);
	}

}
