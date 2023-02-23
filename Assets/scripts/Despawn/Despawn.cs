using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*
// Destroy the objects
//*/
public abstract class Despawn : GeneralMonobehaviour
{

    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }

  
    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;

        this.DespawnObject();
    }

    protected abstract bool CanDespawn();
  

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

}
