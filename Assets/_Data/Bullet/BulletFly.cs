using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParentObjectFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 7f;
    }
}
