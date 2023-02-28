using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver :GeneralMonobehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int maxHp = 3;
    [SerializeField] protected int minHp = 0;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    private void LoadSphereCollider()
    {
        if (sphereCollider != null) return;

        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.9f;
    }

    // hoi sinh
    private void Reborn()
    {
        this.hp = maxHp;
        this.isDead = false;
    }

    // plus hp
    public virtual void Add(int deduct)
    {
        if (this.isDead) return;

        this.hp += deduct;

        if (this.hp > maxHp) this.hp = maxHp;

    }

    // minus hp
    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        if (this.hp < minHp) this.hp = minHp;
        this.CheckIsDead();
        //Destroy(transform.parent.gameObject);
    }

    private void CheckIsDead()
    {
       if(!this.IsDead()) return ;
       this.isDead = true;
       this.OnDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= minHp;
    }

    protected virtual void OnDead()
    {
        // For Override
    }

}
