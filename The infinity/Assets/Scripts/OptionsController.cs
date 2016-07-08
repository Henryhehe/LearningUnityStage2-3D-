using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider DiffcultySlider;
	public LevelManager levelManager;

	private MusicPlayer musicPlayer;

	// Use this for initialization
	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolumn();
		DiffcultySlider.value = PlayerPrefsManager.GetDifficulty();
		
	}
	
	// Update is called once per frame
	void Update () {
		musicPlayer.ChangeVolume(volumeSlider.value);
	}
	public void SaveAnExit() {
		PlayerPrefsManager.SetMasterVolumn(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(DiffcultySlider.value);
		print("what happened here?");
		levelManager.LoadLevel("Start");
	}
	public void setDefault() {
		volumeSlider.value = 0.5f;
		DiffcultySlider.value = 1;	
	}
}

