using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SpawnPoint : MyMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    public virtual void LoadPoints()
    {
        if (this.points.Count > 0) return;

        foreach (Transform point in transform)
        {
            this.points.Add(point);
        }

        Debug.Log($"{transform.name}: LoadPoints, {gameObject}");
    }

    public virtual Transform GetRandom()
    {
        int random = UnityEngine.Random.Range(0, this.points.Count);
        return this.points[random];
    }
}
