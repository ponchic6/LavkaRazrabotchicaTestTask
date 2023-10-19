using System;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector3> OnMoveDirectionChange;
    public event Action OnButtonTakeClick;
    public event Action<Quaternion> OnMouseMovement;
}