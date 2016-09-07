using UnityEngine;
using System.Collections;
using System.Data;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


// Room generator this is a part of the core game system 
// should it be a static class? 
// or it can be singleton patern? because we will only need one generator of the whole game. or a single scene
public class RandomRoomGenerator : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//TODO
//Generate a random index between 1 - 64 and then write it back to a json file.
	int GenerateIndex ()
	{
		return UnityEngine.Random.Range(1,64);
	}
	void WriteToJson() {

	}
}

public class Room {
[JsonProperty]
	public int Index { get; set; }

	public Room( int index) {
		this.Index = index;

	}


}
