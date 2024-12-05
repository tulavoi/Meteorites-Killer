using System.Collections.Generic;
using UnityEngine;

public class Inventory : MyMonoBehaviour
{
	[SerializeField] protected int maxSlot = 70;
	[SerializeField] protected List<ItemInventory> items;

	protected override void Start()
	{
		base.Start();
		//this.AddItem(ItemCode.IronOre, 4);
	}

	public bool AddItem(ItemCode itemCode, int addCount)
	{
		ItemInventory itemInventory = this.GetItemByCode(itemCode);

		int newCount = itemInventory.itemCount + addCount;
		if (newCount > itemInventory.maxStack) return false;
		itemInventory.itemCount = newCount;
		return true;
	}

	private ItemInventory GetItemByCode(ItemCode itemCode)
	{
		ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
		if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);

		return itemInventory;
	}

	private ItemInventory AddEmptyProfile(ItemCode itemCode)
	{
		var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
		foreach (ItemProfileSO profile in profiles)
		{
			if (profile.itemCode != itemCode) continue;
			ItemInventory itemInventory = new ItemInventory()
			{
				itemProfile = profile,
				maxStack = profile.defaultMaxStack
			};
			this.items.Add(itemInventory);
			return itemInventory;
		}
		return null;
	}
}
