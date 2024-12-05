using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentObjectFly
{
    [SerializeField] protected float minCamPos = -9f;
    [SerializeField] protected float maxCamPos = 9f;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    private void GetFlyDirection()
    {
        Vector3 camPos = GameController.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += UnityEngine.Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += UnityEngine.Random.Range(this.minCamPos, this.maxCamPos);

        // Tính toán vector chênh lệch giữa main camera position và object position.
        // Vector này đại diện cho khoảng cách và hướng từ object tới main camera.
        Vector3 diff = camPos - objPos;

        // Biến đổi vector diff thành vector đơn vị (vector có độ dài bằng 1)
        diff.Normalize(); 

        /* 
         * Tính toán góc quay dựa trên vector chênh lệch diff.
         * Dụng hàm Mathf.Atan2 để lấy góc giữa trục x và y trong hệ tọa độ 2D. 
         * Đổi kq tính đc từ radian sang độ với Mathf.Rad2Deg
         */
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        // Đặt góc quay của parent object dựa trên góc vừa tính toán. Object sẽ quay để hướng theo hướng của main camera.
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        // Vẽ 1 đường thẳng màu đỏ để hình dung đường bay của object, từ object tới một điểm cách nó một khoảng bằng 7.
        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);    
    }
}
