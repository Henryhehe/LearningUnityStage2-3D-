using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
// this class is for each item, handling the extra information an item
// has in the inventory panel
public class ItemData : JsonTest2, IBeginDragHandler,IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler {

	// Use this for initialization
	public int amount = 0;

	public Staff staff;

	private int slotIndex;

	void Start() {

		
	}


	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
//		if(amount != 0) {
//		 // the position of the mouse position,evenData gives the data for the event
//		 this.transform.position = eventData.position;
//
//		}
	}
	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
	}

	#endregion

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		Debug.Log("this method get called at all? 3");
	}

	#endregion

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{	
		Debug.Log ("this method get called at all? 1");

		if (staff != null) {

		JsonTest2.informationString = staff.description;
		JsonTest2.SpriteToDisplay = staff.slug;
		}
	}

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		Debug.Log("this method get called at all? 2");
		if (staff!=null) {
			JsonTest2.informationString = " ";
		}
		
	}
	#endregion
}
