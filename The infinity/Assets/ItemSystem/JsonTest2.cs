using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class JsonTest2 : MonoBehaviour {

	// so why has it helped after we changing to static?
	//TODO figure out this

	public static List<Staff> dataList;
	public static List<Staff> ItemList;

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

		inventory.addItem (0);
		inventory.addItem(1);

		BuildToItemsList();
		BuildFromTheItemList();

		informationString = informationText.text;
		SpriteToDisplay = " ";
	}
	// Update method for the sprite display and text display
	void Update ()
	{
		if(informationText!= null) {
		if (informationText.text!= informationString) {
			informationText.text = informationString;
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
[JsonObject]
public class Staff {
	[JsonProperty]
	public string color { get; set; }
	[JsonProperty]
	public int index {get;set;}
	[JsonProperty]
	public string type { get; set;}
	[JsonProperty]
	public bool used { get; set; }
	[JsonProperty]
	public string description { get; set; }
	[JsonProperty]
	public bool stackable { get; set; }
	[JsonProperty]
	public string slug {get; set;}
	[JsonIgnore]
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
          'index': 1,
          'type': 'key',
          'used': true,
          'stackable': true,
          'description': 'this is a black key',
          'slug' : 'key_black'
        },{
          'color': 'yellow',
          'index': 2,
          'type': 'key',
          'used': true,
          'stackable': true,
          'description': 'this is a yellow key',
          'slug' : 'key_yellow'
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
	void BuildFromTheItemList() {
		string path = Application.streamingAssetsPath + "/playerItems.json"; 
		StreamReader sr = new StreamReader (path);
		string readJson = sr.ReadToEnd ();
		ItemList =  JsonConvert.DeserializeObject<List<Staff>> (readJson);
		Debug.Log(ItemList[0].description);
	}
//TODO
//method to build whatever the player has to a json file
//we will need to have access to the staffs list
	void BuildToItemsList ()
	{
		string path = Application.streamingAssetsPath + "/playerItems.json"; 
		StringBuilder jsonTowrite = new StringBuilder ();
		jsonTowrite.Append ("[");
	
		foreach (Staff staffToWrite in inventory.staffs) {
			if (staffToWrite.index != -1) {
				string json = JsonConvert.SerializeObject(staffToWrite, Formatting.Indented) + ",";
				jsonTowrite.Append(json);
			}
		}
		jsonTowrite.Length--;
		jsonTowrite.Append("]");
		string jsontoBuild = jsonTowrite.ToString();

		System.IO.File.WriteAllText (path, jsontoBuild);
	}
//TODO 
//method to delete whatever the player has used.
	void CheckDeletion() {


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
