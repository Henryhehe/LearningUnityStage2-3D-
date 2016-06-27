using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ScoreKeeper : MonoBehaviour {

	public Text[] rollTexts,frameTexts; 
	// Use this for initialization

	public void FillRolls(List<int> rolls) {
		string scoreString = FormatRolls(rolls);
		for (int i = 0; i < scoreString.Length; i++) {
			rollTexts[i].text = scoreString[i].ToString();
		}

	}

	public void FillFrames (List<int> frames)
	{
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	static string FormatRolls (List<int> rolls)
	{
		string output = "";

		for (int i = 0; i < rolls.Count; i++) {
			int box = output.Length + 1; 		//score box from 1 to 21

			if (rolls [i] == 0) {
				output += "-";					//always enter 0 as -
			} else if ((box % 2 == 0 || box == 21)&& rolls [i - 1] + rolls [i] == 10) { // SPARE anywhere
				output += "/";
			} else if (box >= 19 && rolls [i] == 10) {
				output += "X";
			} else if (rolls [i] == 10) {
				output += "X";
			} else {
				output += rolls[i].ToString();
			}	
	}
		return output;
}

}
