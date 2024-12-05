using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float rotateSpeed = 9f;

    private void FixedUpdate()
    {
        this.Rotaing();
    }

    private void Rotaing()
    {
        Vector3 eulers = new Vector3(0, 0, 1); // Đại diện cho hướng quay của object
        this.JunkController.Model.Rotate(eulers * this.rotateSpeed * Time.fixedDeltaTime);
    }
}
