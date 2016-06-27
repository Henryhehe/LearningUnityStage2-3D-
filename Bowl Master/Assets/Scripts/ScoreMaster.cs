using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster{

	// Return a list of individual frame scores, Not cumulative 
	public static List<int> ScoreFrames (List<int> rolls)
	{
		List<int> frameList = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {

			if (rolls [i - 1] + rolls [i] < 10) {	// Normal "Open" frame
				frameList.Add (rolls [i - 1] + rolls [i]);
			}
			if (rolls.Count - i <= 1) {
				break;							// Ensure at leaast 1 look-ahead available 
			} 

			if (rolls [i - 1] == 10) {			//Strike
				i--;			
				frameList.Add (10 + rolls [i + 1] + rolls [i + 2]);
			} else if (rolls [i - 1] + rolls [i] == 10) {	//Spare bonues
				frameList.Add(10 + rolls[i+1]);
			}
			}
		// return the right frame list, return the currently 
		return frameList;
	}
	// a list of a cumulative score 
	public static List<int> ScoreCumulative (List<int> rolls)
	{
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}



}
