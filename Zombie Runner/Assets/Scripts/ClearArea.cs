using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

	private float timeSinceLastTrigger = 0;
	private bool foundClearArea = false;

	// Update is called once per frame
	void Update ()
	{

		timeSinceLastTrigger += Time.deltaTime;
		if (timeSinceLastTrigger > 5.0f && Time.realtimeSinceStartup > 60.0f && !foundClearArea) {
			SendMessageUpwards("OnFindClearArea");
			foundClearArea = true;
		}
	}
	// the player itself can trigger it
	void OnTriggerEnterStay (Collider collider)
	{
	if(collider.tag !="Player")
		timeSinceLastTrigger = 0;
	}


}
