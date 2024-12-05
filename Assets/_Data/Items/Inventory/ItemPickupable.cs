using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Transactions;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : JunkAbstract
{
	[Header("Item Pickupable")]
    [SerializeField] protected SphereCollider _collider;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadTrigger();
	}

	private void LoadTrigger()
	{
		if (this._collider != null) return;
		this._collider = transform.GetComponent<SphereCollider>();
		this._collider.isTrigger = true;
		this._collider.radius = 0.1f;
	}

	public ItemCode GetItemCode()
	{
		return ItemPickupable.StringToItemCode(transform.parent.name);
	}

	private static ItemCode StringToItemCode(string itemName)
	{
		try
		{
			return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
		}
		catch (ArgumentException ex)
		{
			Debug.LogError(ex.ToString());
			return ItemCode.NoItem;
		}
	}

	public void OnMouseDown()
	{
		//Debug.Log(transform.parent.name);
		PlayerController.Instance.PlayerPickup.ItemPickup(this);
	}

	internal void Picked()
	{
		this.JunkController.JunkDespawn.DespawnObject();
	}
}
