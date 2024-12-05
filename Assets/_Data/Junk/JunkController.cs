using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class JunkController : MyMonoBehaviour
{
    [SerializeField] private Transform model;
    public Transform Model => model;

    [SerializeField] private JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;

    [SerializeField] private JunkSO junkSO;
    public JunkSO JunkSO => junkSO; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    private void LoadJunkSO()
    {
        if (this.junkSO != null) return;
        string resPath = $"Junk/{transform.name}";
        this.junkSO = Resources.Load<JunkSO>(resPath);
        Debug.LogWarning($"{transform.name}: LoadJunkSO(), {resPath}, {gameObject}");
    }

    private void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log($"{transform.name}: LoadJunkDespawn() {gameObject}");
    }

    private void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log($"{transform.name}: LoadModel() {gameObject}");
    }
}
