using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MyMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadInvetory();
	}

	private void LoadInvetory()
	{
		if (this.inventory != null) return;
		this.inventory = transform.GetComponentInChildren<Inventory>();
		Debug.Log($"{transform.name}: LoadInventory() {gameObject}");
	}
}
