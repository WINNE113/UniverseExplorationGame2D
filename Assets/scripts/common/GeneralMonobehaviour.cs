using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMonobehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.LoadValue();
    }

    protected virtual void LoadValue()
    {
        // For Override 
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For Override
    }

    protected virtual void LoadComponents()
    {
        // For Override
    }

    protected virtual void OnEnable()
    {
        Debug.Log("Object Enabled");
    }

}
