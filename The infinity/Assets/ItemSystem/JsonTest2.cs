using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class JsonTest2 : MonoBehaviour {

	// so why has it helped after we changing to static?
	//TODO figure out this

	public static List<Staff> dataList;

	public Text informationText;
	public Image informationImage;
	public static string informationString;
	public static string SpriteToDisplay;

	private static Inventory inventory;


	// Use this for initialization
	void Start ()
	{

		BuildTheDataList ();

		inventory = GetComponent<Inventory>();
		inventory.CreateSlot ();

		inventory.addItem (2);
		inventory.addItem (2);
		inventory.addItem (2);
		inventory.addItem (0);

		informationString = informationText.text;
		SpriteToDisplay = " ";
	}

	void Update ()
	{
		if(informationText!= null) {
		if (informationText.text!= informationString) {
			informationText.text = informationString;
			Debug.Log(informationString);
		}
		}
		if(informationImage!=null ) {
		if(informationImage.GetComponent<Image>().name!= SpriteToDisplay)
		informationImage.sprite = Resources.Load<Sprite> ("ItemSystem/Sprites/" + SpriteToDisplay);
		}
	}

// helper method to find the staff by index
//TODO make multiple help methods to fetch different thing

	public Staff FetchStaffByID (int id)
	{
	// loop through the data list to find the staff with given index 
		for (int i = 0; i < dataList.Count; i++) {
		if(dataList[i].index == id) return dataList[i];
		}
		Debug.Log("didn't find the staff, return null");
		return null;
	}
	

// the staff class that we're actually using 
//[System.Serializable]
public class Staff {
	public string color { get; set; }
	public int index {get;set;}
	public string type { get; set;}
	public bool used { get; set; }
	public string description { get; set; }
	public bool stackable { get; set; }
	public string slug {get; set;}
	public Sprite sprite { get; set; }

	public Staff(string color, int index,string type, bool used, string descriptipn, bool stackable, string slug){
	this.color = color;
	this.index = index;
	this.type = type;
	this.used = used;
	this.description = description;
	this.stackable = stackable;
	this.slug = slug;
	// go through the resource
	}

	public Staff() {
	this.index = -1;
	}

	// empty staff class, can be used as a deleted item etc.

}


// this method is to build the json file, the ideal way is to use text editor but I think that
// is not that stable, so we can just do it here 
	private string buildToJson (string path)
	{
		string json = @"[
		{
		  'color': 'blue',
          'index': 0,
          'type': 'key',
          'used': true,
          'stackable': false,
          'description': 'this is a blue key',
          'slug': 'key_blue'
        },{
          'color': 'black',
          'index': 2,
          'type': 'shit',
          'used': true,
          'stackable': true,
          'description': 'this is a black shit',
          'slug' : 'shit_black'
        }
        ]";
		System.IO.File.WriteAllText(path,json);
		return json;
	}

	void BuildTheDataList ()
	{
		// using the StreamReader to read the file into string, and deseriazlize to a collection 
		string path = Application.streamingAssetsPath + "/items.json";
		string json = buildToJson (path);
		StreamReader sr = new StreamReader (path);
		string readJson = sr.ReadToEnd ();
		//		Debug.Log (readJson);
		// deseriazlize to a list collection, can also be a dictionary
		dataList = JsonConvert.DeserializeObject<List<Staff>> (readJson);
		sr.Close ();
	}

// this is the deserializing example, not sure which example it works on but it sure does 
// works on some examples....
	static void Deserializing (ref IList<Staff> staffs, string json)
	{
		JsonTextReader reader = new JsonTextReader (new StringReader (json));
		reader.SupportMultipleContent = true;
		while (true) {
			if (!reader.Read ()) {
				break;
			}
			staffs = JsonConvert.DeserializeObject<List<Staff>> (json);
		}
		foreach (Staff staffe in staffs) {
			Debug.Log (staffe.type);
		}
	}
}
