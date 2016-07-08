using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	const string MASTER_VOLUMN_KEY = "master_volumn";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	// level_unlocked_1 
	// static means it only has one method and called in the class itself 
	public static void SetMasterVolumn (float volumn)
	{
		if (volumn > 0f && volumn < 1.0f) {
			PlayerPrefs.SetFloat (MASTER_VOLUMN_KEY, volumn);
		} else {
			Debug.LogError("error setting volumn, please choose between 0 to 1");
		}
	}
	public static float GetMasterVolumn() {
		return PlayerPrefs.GetFloat (MASTER_VOLUMN_KEY);
	}
	public static void UnlockLevel (int level)
	{
		if(level<= SceneManager.sceneCount - 1) {
		PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(),1); //
		}else {
			Debug.LogError("Error");
		}
	}
	public static bool boolIsLevelUnlocked(int level){
	if(level <= SceneManager.sceneCount - 1){
      if(PlayerPrefs.GetInt(LEVEL_KEY + level.ToString())==1) {
		return true;
	}}
	else{return false ;
	}
	return false;
	}

	public static void SetDifficulty (float difficulty)
	{
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY,difficulty);
		}else{
			Debug.LogError("error setting the difficulty");
		}
	}
	public static float GetDifficulty ()
	{
	 return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
