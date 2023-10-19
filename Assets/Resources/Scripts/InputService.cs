using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : IInputService
{
    public event Action<Vector3> OnMoveDirectionChange;
    public event Action OnButtonTakeClick;
    public event Action<Quaternion> OnMouseMovement;

    private float _xRot;
    private float _yRot;
    
    public InputService(ITickService tickService)
    {
        tickService.OnTick += CheckNewMoveDirection;
        tickService.OnTick += CheckButtonTakeClick;
        tickService.OnTick += CheckMouseMovement;
    }

    private void CheckMouseMovement()
    {
        Quaternion mouseRot = GetMouseRotation();
        OnMouseMovement?.Invoke(mouseRot);
    }

    private Quaternion GetMouseRotation()
    {
        _xRot += Input.GetAxis("Mouse X");
        _yRot += Input.GetAxis("Mouse Y");
        
        return Quaternion.Euler(-_yRot, _xRot, 0);
    }

    private void CheckButtonTakeClick()
    {
        if (Input.GetMouseButtonDown(0))
            OnButtonTakeClick?.Invoke();
    }

    private void CheckNewMoveDirection()
    {
        Vector3 direction = GetInputVector();
        OnMoveDirectionChange?.Invoke(direction);
    }

    private Vector3 GetInputVector()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }
}