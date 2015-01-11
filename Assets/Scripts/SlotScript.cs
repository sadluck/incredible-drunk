﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotScript : MonoBehaviour, IPointerDownHandler,IPointerEnterHandler, IPointerExitHandler {

	public Item item;

	Image itemImage;
	Inventory inventory;


	// Use this for initialization
	void Start () {
		itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
		inventory = gameObject.transform.parent.GetComponent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (item != null) {
				itemImage.enabled = true;
				itemImage.sprite = item.Icon;
		} else {
			itemImage.enabled = false;
		}
	}

	void SayUsTheName(){
		Debug.Log (this.name);
	}

	#region IPointerDownHandler implementation
	public void OnPointerDown (PointerEventData eventData)
	{
		Debug.Log("Click ");
		if (item != null) {
			Debug.Log("I have a item " + this.item.Name);
		}
	}
	#endregion

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
				if (this.item != null) {
						inventory.ShowTooltip (this.transform.GetComponent<RectTransform> ().localPosition, this.item);
				}
	}

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		inventory.HideTooltip ();
	}

	#endregion
	#endregion
}
