using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MyMonoBehaviour
{
    [Header("Damage Sender")]
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateImpactFX();
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

	private void CreateImpactFX()
	{
		string fxName = this.GetImpactFX();

		Vector3 hitPos = transform.position;
		Quaternion hitRot = transform.rotation;
		Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
		fxImpact.gameObject.SetActive(true);
	}

	private string GetImpactFX()
	{
		return FXSpawner.impactOne;
	}
}
