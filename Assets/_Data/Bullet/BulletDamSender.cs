using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [SerializeField] protected BulletController bulletController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    private void LoadBulletController()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log($"{transform.name}: LoadBulletController(), {gameObject}");
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    private void DestroyBullet()
    {
        this.bulletController.BulletDespawn.DespawnObject();
    }
}
