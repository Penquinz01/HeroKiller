using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler
{
    private MainControls _controls;
    public float _moveInput{get; private set;}
    public Action jumpEvent;
    public Action actionEvent;

    public InputHandler()
    {
        _controls = new MainControls();
        _controls.Enable();
        _controls.Main.Enable();
        _controls.Main.Movement.performed += ctx =>  _moveInput = ctx.ReadValue<float>();
        _controls.Main.Movement.canceled += ctx =>  _moveInput = 0;
        _controls.Main.Jump.started += ctx =>  jumpEvent?.Invoke();
        _controls.Main.Attack.started += ctx =>  actionEvent?.Invoke();
    }
}
