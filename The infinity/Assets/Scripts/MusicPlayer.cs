using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
//	static MusicPlayer instance = null;
//	public AudioClip startClip;
//	public AudioClip gameClip;
//	public AudioClip endClip;
//
	private int CurrentSceneIndex;
	public AudioClip[] LevelMusicArray;
	private AudioClip audioClip;
	private AudioSource audioSource;
	private int previousIndex;
	// Use this for initialization
	void Awake ()
	{ 
		DontDestroyOnLoad(gameObject);
//			print("Dupilicate music player self-destructing!");
//		} else {
//	// it claims the instance, because oh..this is the static variable of the class
//		 instance = this;
//		GameObject.DontDestroyOnLoad (gameObject);
////		music = GetComponent<AudioSource>();
//	}
	}
	void Start() {
		audioSource = this.GetComponent<AudioSource>();

	}
	void LoadOnSceneMusic (int Index)
	{
		audioClip = LevelMusicArray [Index];
		if (audioSource.clip != audioClip) {
			audioSource.clip = audioClip;
			audioSource.Play ();
			audioSource.loop = true;
			previousIndex = Index;
		}
	}

	void Update() {
	// this probably a bad idea having it running here every Scene, very bad idea.
	if(SceneManager.GetActiveScene().buildIndex!=previousIndex)
	LoadOnSceneMusic(SceneManager.GetActiveScene().buildIndex);	

	}
	// Update is called once per frame
//	void OnLevelWasLoaded (int level)
//	{
//		Debug.Log ("MusicPlyaer:Loaded" + level);
//		music.Stop ();
//		if (level == 0) {
//			music.clip = startClip;
//		} else if (level == 1) {
//		music.clip = gameClip;
//		}else if(level ==2) {
//		music.clip = endClip;
//		}
//	music.Play();
//	music.loop = true;
//	}
	public void ChangeVolume (float volume)
	{
		audioSource.volume = volume;
	}
//	void PlayMusic(int i) {
//		audioSource = LevelMusicArray[i];
//	}
}
