using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Despawn object by distance from main camera to object
/// </summary>
public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCamera;


    protected override void LoadComponents()
    {
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;

        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;

        Debug.Log(transform.parent.name + ": LoadCamera", gameObject);
    }

    // get distance from current possiton to camera position than distanceLimit (70f)
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        if (this.distance > disLimit) return true;

        return false;
    }
}
