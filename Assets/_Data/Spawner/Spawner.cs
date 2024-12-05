using System;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public abstract class Spawner : MyMonoBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjects;

    [SerializeField] private int spawnedCount = 0;
    public int SpawnedCount { get => spawnedCount; }

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
    }

    private void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log($"{transform.name}: LoadHolder {gameObject}");
    }

    private void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObject = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObject)
        {
            this.prefabs.Add(prefab);
        }

        this.HidePrefabs();
        Debug.Log($"{transform.name}: LoadsPrefab {gameObject}");
    }

    private void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(prefabName);

        if (prefab == null)
        {
            Debug.LogWarning($"Prefab not found");
            return null;
        }

        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);

        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObject in this.poolObjects)
        {
            if (poolObject.name == prefab.name)
            {
                this.poolObjects.Remove(poolObject);
                return poolObject;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual Transform RandomPrefab()
    {
        int random = UnityEngine.Random.Range(0, this.prefabs.Count);
        return this.prefabs[random];
    }
}
