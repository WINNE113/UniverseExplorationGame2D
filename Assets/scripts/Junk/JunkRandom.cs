using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : GeneralMonobehaviour
{
    [SerializeField] protected JunkSpawnerCtrl JunkSpawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

 

    private void LoadJunkCtrl()
    {
        if (this.JunkSpawnerCtrl != null) return;
        
        this.JunkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();

        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    /// <summary>
    /// use recursive to spawn (5s will spawn one time)
    /// </summary>
    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.JunkSpawnerCtrl.SpawnPoints.GetRanDom();

        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform obj = JunkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.MateoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
      
        Invoke(nameof(this.JunkSpawning), 5f);
        Debug.Log("Spawning object");
    }
}
