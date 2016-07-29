using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;

public class Inventory : JsonTest2 {

	public GameObject inventorySlot;
	public GameObject inventoryItem;
	// back end representation and frontend representation 
	public List<Staff> staffs = new List<Staff>();
	public List<GameObject> slots = new List<GameObject>();
	// which is actually the itemScreen
	public GameObject inventoryPanel;
	// which is the actual slot panel 
	public GameObject slotPanel;

	private const int slotAmount = 15;

	void Start ()
	{
		
	}

	public void CreateSlot ()
	{
		
		// create slot and add to the list as wekk
		for (int i = 0; i < slotAmount; i++) {
			GameObject slotToAdd = (GameObject)Instantiate (inventorySlot);
			staffs.Add(new Staff());
			slotToAdd.transform.SetParent (slotPanel.transform, false);
			slots.Add (slotToAdd);
			//set the parent to be the slot panel, will follow the grid layout flow if you set it to false 
			//			slots[i].transform.SetParent(slotPanel.transform);
		}
	}

	public void addItem (int id)
	{
		Staff staffToAdd = FetchStaffByID (id);
// add the sprite to the item at the runtime, not sure if it is the best solution but at least it works
		staffToAdd.sprite = Resources.Load<Sprite> ("ItemSystem/Sprites/" + staffToAdd.slug);
// implementaing stackable feature

		if (staffToAdd.stackable && staffs.Contains (staffToAdd)) {
			ItemData data = slots[staffs.IndexOf(staffToAdd)].transform.GetChild(0).GetComponent<ItemData>();
			data.amount++;
			data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();

		} 
		else {
// the index of the item in the staffs list is the same the index of the item in the slot list
			for (int i = 0; i < staffs.Count; i++) {
				if (staffs [i].index == -1) {
					staffs [i] = staffToAdd;
					GameObject itemObject = Instantiate (inventoryItem);
					itemObject.GetComponent<ItemData>().staff = staffToAdd;
					itemObject.transform.SetParent (slots[i].transform, false);
					// the sprite value, 
					itemObject.GetComponent<Image> ().sprite = staffToAdd.sprite;
					itemObject.name = staffToAdd.type;
					itemObject.GetComponent<ItemData>().amount = 1;
					// add to the json file 
					AddToJson(staffToAdd);
					// relative to the parent, and the parent is to it.
					break;
				}
			}	
		}
	}


	private void AdjustUI(GameObject itemObject) {

		itemObject.GetComponentInChildren<Text>().text = itemObject.GetComponent<ItemData>().amount.ToString();
	}

//TODO 
//a seprate helper method to add staff into the json file, hence the path should be known, or delete

	private void AddToJson (Staff staffToAdd)
	{
//		string json = JsonConvert.SerializeObject(staffToAdd, Formatting.Indented);
//		Debug.Log(json);
	}
//TODO
//another helper method to delete staff from the json file 

	private void DeleteToJson(Staff staffToDelete) {


	}
}
