using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	
	public GameObject mainMenu;


	private GameObject itemsMenu;
	private Camera eyes;
	private FirstPersonController playerController;
	private float defaultFov;
//	private bool canLook = true;


	CursorMode wantedMode;
	private int i = 1;
	// Use this for initialization
	void Start () {
	eyes = GetComponentInChildren<Camera>();
	defaultFov = eyes.fieldOfView;
	itemsMenu = GameObject.Find("Menu");
	playerController = GetComponent<FirstPersonController>();
	}
	// Update is called once per frame
	void Update ()
	{
		// if the button has been pressed, the FOV would be half 
		if (Input.GetButtonDown ("Focus")) {
			print ("v has been pressed");
			eyes.fieldOfView = defaultFov / 2.0f;
		}
		// if the button has been realeased,the FOV would be reset to default 
		if (Input.GetButtonUp ("Focus")) {
			eyes.fieldOfView = defaultFov;
		}
	// this one should handle the situation while the player just press the button 
		if (Input.GetButtonDown ("Items")) {
			EnableCavas ();
		}
		if (Input.GetButton ("ExitScreen")) {
			DisableMenu();
		}
	}
	// this is the method to handld input to control the canvas 

	void EnableCavas ()
	{
		print ("c has been pressed");
		if (i % 2 != 0) {
			EnableMenu ();
			i++;
		} else {
			DisableMenu ();
			i++;
		}
	}
// two helper method to help with the mouseLook 

	void EnableMenu ()
	{
		playerController.enabled = false;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		itemsMenu.GetComponent<Canvas> ().enabled = true;
		mainMenu.SetActive(true);
	}

	void DisableMenu ()
	{
		playerController.enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		itemsMenu.GetComponent<Canvas> ().enabled = false;
		mainMenu.SetActive(false);
	}
}
