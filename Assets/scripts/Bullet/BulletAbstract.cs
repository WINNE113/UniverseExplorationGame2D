using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : GeneralMonobehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get { return bulletCtrl; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    private void LoadDamageReceiver()
    {
        if (this.bulletCtrl != null) return;

        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();

        Debug.Log(transform.name + ": LoadDameReceiver", gameObject);
    }
}
