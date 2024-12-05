using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MyMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] public BulletController bulletController;

    public BulletController BulletController { get => bulletController; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    private void LoadDamageReceiver()
    {
        if (this.bulletController != null) return;
        this.bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log($"{transform.name}: LoadDamageReceiver(), {gameObject}");
    }
}
