using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : GeneralMonobehaviour
{
    [SerializeField] protected Camera mainCamerea;

    private static GameCtrl instance;

    public Camera MainCamera { get { return mainCamerea; } }

    public static GameCtrl Instance { get { return instance; } }


    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.Log(transform.name +" :only one gameCtrl init", gameObject);
        }
        GameCtrl.instance = this;
       
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
    }

    private void LoadMainCamera()
    {
        if (mainCamerea != null) return;
        this.mainCamerea = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": Load Camera ", gameObject);
    }
}
