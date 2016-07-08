using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if(SceneManager.GetActiveScene ().name == "SplashScene"){
			print("here?");
			Invoke("LoadNextLevel", 5);
		}
	}
	public void LoadLevel(string name)
	{
		// fade Out the game and load a new level  IEnumerator 
//		float fadeTime = GameObject.Find("MusicPlayer").GetComponent<Fading>().BeginFade(1);
//		yield return new WaitForSeconds(fadeTime);
		print("I'm trying to load a level here,come on");
	    SceneManager.LoadScene(name);
	}
	public void Quit ()
	{
		
		Application.Quit();
	}
	public void LoadNextLevel ()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

	}

}
