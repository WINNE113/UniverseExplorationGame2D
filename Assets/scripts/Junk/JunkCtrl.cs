using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : GeneralMonobehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;

    public JunkDespawn JunkDespawn { get { return junkDespawn; } }
    public Transform Model { get { return model; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
    }

    private void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = GetComponentInChildren<JunkDespawn>();
    }

    private void LoadModel()
    {
        if (this.model != null) return;

        this.model = transform.Find("Model");

        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
}
