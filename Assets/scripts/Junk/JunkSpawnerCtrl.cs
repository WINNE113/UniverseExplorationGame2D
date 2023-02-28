using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : GeneralMonobehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;

    [SerializeField] protected JunkSpawnPoints spawnPoints;


    public JunkSpawner JunkSpawner { get { return junkSpawner; } }

    public JunkSpawnPoints SpawnPoints { get { return spawnPoints; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }
    private void LoadSpawnPoints()
    {
        if (this.spawnPoints != null) return;

        this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();

        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }

    private void LoadJunkSpawner()
    {
        if (junkSpawner != null) return;

        this.junkSpawner = GetComponent<JunkSpawner>();
    }
}
