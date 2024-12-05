using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    private void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log($"{transform.name}: LoadCollider(), {gameObject}");
    }

    private void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log($"{transform.name}: LoadRigidbody(), {gameObject}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletController.Shooter) return;

        this.BulletController.DamageSender.Send(other.transform);
        //this.CreateImpactFX(other);
    }

    //private void CreateImpactFX(Collider other)
    //{
    //    string fxName = this.GetImpactFX();

    //    Vector3 hitPos = transform.position;
    //    Quaternion hitRot = transform.rotation;
    //    Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
    //    fxImpact.gameObject.SetActive(true);
    //}

    //private string GetImpactFX()
    //{
    //    return FXSpawner.impactOne;
    //}
}
