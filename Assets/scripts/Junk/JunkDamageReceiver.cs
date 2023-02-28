using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    private void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;

        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
    }

    protected override void OnDead()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
