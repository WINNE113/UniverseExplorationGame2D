using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : GeneralMonobehaviour
{
    [SerializeField] protected DamageSender damageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;

    public DamageSender DamageSender { get { return damageSender; } }

    public BulletDespawn BulletDespawn { get { return bulletDespawn; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    private void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
    }

    private void LoadDamageSender()
    {
        if (this.damageSender != null) return;

        this.damageSender = GetComponentInChildren<DamageSender>();

        Debug.Log(transform.name + ": Load DameSender", gameObject);
    }
}
