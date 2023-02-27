using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;

    public static string MateoriteOne = "Mateorite_1";


    public static JunkSpawner Instance { get { return instance; } }

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null)
        {
            Debug.LogError("Only 1 JunkSpawner allow to exit");
        }
        JunkSpawner.instance = this;
    }

}
