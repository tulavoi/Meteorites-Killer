using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCam;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, mainCam.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    private void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log($"{transform.parent.name}: Load Camera {gameObject}");
    }
}
