using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MyMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    private void FixedUpdate()
    {
        this.Following();
    }

    private void LoadTarget()
    {
        if (this.target != null) return;
        this.target = transform.Find("Ship");
        this.target = GameObject.Find("Ship").transform;
    }

    private void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
    }
}
