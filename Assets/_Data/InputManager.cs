using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get => instance; }
    
    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] private float onFiring;
    public float OnFiring { get => onFiring; set => onFiring = value; }

    private void Awake()
    {
        if (InputManager.instance != null)
            Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    private void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
