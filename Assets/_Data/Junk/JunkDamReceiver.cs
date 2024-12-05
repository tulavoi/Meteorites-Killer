using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamReceiver : DamageReceiver
{
    [Header("Junk Damage Receiver")]
    [SerializeField] protected JunkController junkController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    private void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log($"{transform.name}: LoadJunkController(), {gameObject}");
    }

    public override void OnDead()
    {
        this.OnDeadFX();
        this.DropOnDead();
        this.junkController.JunkDespawn.DespawnObject();
    }

    public void DropOnDead()
    {
		Vector3 dropPos = transform.position;
		Quaternion dropRot = transform.rotation;
		Debug.Log($"DropOnDead: {transform.name}");

		ItemDropSpawner.Instance.Drop(this.junkController.JunkSO.dropList, dropPos, dropRot);
	}

    public virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    private string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }

    public override void Reborn()
    {
        this.maxHP = this.junkController.JunkSO.maxHP;
        base.Reborn();
    }
}
