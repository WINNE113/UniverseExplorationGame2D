using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{
    protected override void LoadValue()
    {
        base.LoadValue();  
        this.moveSpeed = 1f;
    }
}
