using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MyMonoBehaviour
{
	[Header("Player Abstract")]
	[SerializeField] protected PlayerController playerController;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadPlayerController();
	}

	private void LoadPlayerController()
	{
		if (playerController != null) return;
		this.playerController = transform.GetComponentInParent<PlayerController>();
		Debug.Log($"{transform.name}: LoadPlayerController() {gameObject}");
	}
}
