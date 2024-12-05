using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MyMonoBehaviour
{
    private static PlayerController instance;
	public static PlayerController Instance => instance;

	[SerializeField] protected ShipController currShip;
	public ShipController CurrShip => currShip;

	[SerializeField] protected PlayerPickup playerPickup;
	public PlayerPickup PlayerPickup => playerPickup;

	protected override void Awake()
	{
		base.Awake();
		if (PlayerController.instance != null) Debug.LogError("Only 1 PlayerController allow to exist.");
		PlayerController.instance = this;
	}

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadPlayerPickup();
	}

	private void LoadPlayerPickup()
	{
		if (this.playerPickup != null) return;
		this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
		Debug.Log($"{transform.name}: LoadPlayerPickup() {gameObject}");
	}
}
