using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Inventory : JsonTest2 {

	public GameObject inventorySlot;
	public GameObject inventoryItem;
	// back end representation and frontend representation 
	public List<Staff> staffs = new List<Staff>();
	public List<GameObject> slots = new List<GameObject>();


	private const int slotAmount = 15;
	private GameObject inventoryPanel;
	private GameObject slotPanel;

	void Start ()
	{
		
	}

	public void CreateSlot ()
	{
		inventoryPanel = GameObject.Find ("ItemScreen");
		slotPanel = inventoryPanel.transform.FindChild ("Slot Panel").gameObject;
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
					// relative to the parent, and the parent is to it.
					break;
				}
			}	
		}
	}

	private void AdjustUI(GameObject itemObject) {

		itemObject.GetComponentInChildren<Text>().text = itemObject.GetComponent<ItemData>().amount.ToString();
	}
}
