using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 7f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    private void Following()
    {
        if (this.target == null) return;
        
        transform.position = Vector3.Lerp(transform.position, this.target.position,Time.fixedDeltaTime * this.speed);
    }
}
