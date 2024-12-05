using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
	public void ItemPickup(ItemPickupable itemPickupable)
	{
		Debug.Log("ItemPickup");
		ItemCode itemCode = itemPickupable.GetItemCode();
		if (this.playerController.CurrShip.Inventory.AddItem(itemCode, 1))
			itemPickupable.Picked();
	}
}
