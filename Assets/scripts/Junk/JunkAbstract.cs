using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : GeneralMonobehaviour
{

    [SerializeField] protected JunkCtrl junkCtrl;
        
    public JunkCtrl JunkCtrl { get { return junkCtrl; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    private void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;

        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();

        Debug.Log(transform.name + ": Load JunkCtrl" + gameObject.name);
    }
}
