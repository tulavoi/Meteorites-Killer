using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : MyMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
	[SerializeField] protected SphereCollider _collider;
	[SerializeField] protected Rigidbody _rigidbody;

	protected override void LoadComponents()
	{
		this.LoadInventory();
		this.LoadTrigger();
		this.LoadRigidbody();
	}

	private void LoadTrigger()
	{
		if (this._collider != null) return;
		this._collider = transform.GetComponent<SphereCollider>();
		this._collider.isTrigger = true;
		this._collider.radius = 0.3f;
	}

	private void LoadRigidbody()
	{
		if (this._rigidbody != null) return;
		this._rigidbody = transform.GetComponent<Rigidbody>();
		this._rigidbody.useGravity = false;
		this._rigidbody.isKinematic = true;
	}

	private void LoadInventory()
	{
		if (this.inventory != null) return;
		this.inventory = transform.parent.GetComponent<Inventory>();
	}

	private void OnTriggerEnter(Collider collider)
	{
		ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
		if (itemPickupable == null) return;

		ItemCode itemCode = itemPickupable.GetItemCode();
		if (this.inventory.AddItem(itemCode, 1))
			itemPickupable.Picked();
	}
}

