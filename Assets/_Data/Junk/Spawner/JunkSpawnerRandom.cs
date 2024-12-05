using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class JunkSpawnerRandom : MyMonoBehaviour
{
    [Header("Junk Spawner Random")]
    [SerializeField] protected JunkSpawnerController junkSpawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 9f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    private void LoadJunkController()
    {
        if (this.junkSpawnerCtrl != null) return;

        this.junkSpawnerCtrl = GetComponent<JunkSpawnerController>();
        Debug.Log($"{transform.name}: LoadJunkController {gameObject}");
    }

    private void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.ReachRandomLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0f;

        Transform randomPoint = this.junkSpawnerCtrl.SpawnPoint.GetRandom();
        Vector3 pos = randomPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    private bool ReachRandomLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }
}
