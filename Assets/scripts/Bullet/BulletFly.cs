using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParentFly
{
    protected override void LoadValue()
    {
        base.LoadValue();
        this.moveSpeed = 10f;
    }
}
