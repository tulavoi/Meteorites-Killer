using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
	private static ItemDropSpawner instance;

	public static ItemDropSpawner Instance => instance;

	protected override void Awake()
	{
		base.Awake();
		if (instance != null) Debug.Log("Only have ItemDropSpawner allow exist");
		instance = this;
	}

	public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
	{
		ItemCode itemCode = dropList[0].itemSO.itemCode;
		Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
		if (itemDrop == null) return;
		itemDrop.gameObject.SetActive(true);
    }
}
