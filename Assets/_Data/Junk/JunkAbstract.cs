using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : MyMonoBehaviour
{
    [SerializeField] private JunkController junkController;
    public JunkController JunkController { get => junkController; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkController();
    }

    private void LoadJunkController()
    {
        if (this.junkController != null) return;
        this.junkController = transform.parent.GetComponent<JunkController>();
        Debug.Log($"{transform.name}: LoadJunkController() {gameObject}");
    }
}
