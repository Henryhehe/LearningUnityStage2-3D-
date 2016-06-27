using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class  GameManager : MonoBehaviour {

	public static List<int> rolls = new List<int>();

	private PinSetter pinsetter;
	private Ball ball;
	private ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
	pinsetter = GameObject.FindObjectOfType<PinSetter>();
	ball  = GameObject.FindObjectOfType<Ball>();
	scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
	}
	void Update() {


	}
	public void Bowl (int score)
	{
		try {
			rolls.Add (score);
			ActionMasterOld.Action action = ActionMasterOld.NextAction (rolls);
			pinsetter.PerformAction (action);
			ball.reset ();
		} catch {
			Debug.LogWarning ("Warning");
		}	
		try {
			scoreKeeper.FillRolls(rolls);
			scoreKeeper.FillFrames(ScoreMaster.ScoreCumulative(rolls));
			
		} catch {
			Debug.LogWarning("What's going on?");
		}
	}
}
