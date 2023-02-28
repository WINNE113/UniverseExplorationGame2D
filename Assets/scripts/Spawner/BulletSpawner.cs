using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;

    public static string bulletOne = "Bullet_1";

    public static BulletSpawner Instance { get { return instance; } }

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
        {
            Debug.LogError("Only 1 BulletSpawner allow to exit");
        }
        BulletSpawner.instance = this;
    }

  
}
