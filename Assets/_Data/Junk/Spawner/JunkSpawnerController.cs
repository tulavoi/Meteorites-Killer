using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerController : MyMonoBehaviour
{
    [SerializeField] private JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner { get => junkSpawner; set => junkSpawner = value; }


    [SerializeField] private JunkSpawnPoint junkSpawnPoint;
    public JunkSpawnPoint SpawnPoint { get => junkSpawnPoint; set => junkSpawnPoint = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();
    }

    private void LoadSpawnPoint()
    {
        if (this.junkSpawnPoint != null) return;
        this.junkSpawnPoint = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log($"{transform.name}: LoadSpawnPoint {gameObject}");
    }

    private void LoadJunkSpawner()
    {
        if (this.JunkSpawner != null) return;
        this.JunkSpawner = GetComponent<JunkSpawner>();
        Debug.Log($"{transform.name}: LoadJunkSpawner {gameObject}");
    }
}
