using System;
using UnityEngine;
using Zenject;

public class HeroMover : MonoBehaviour, IHeroMove
{
    [SerializeField] private float _speed;

    [Inject]
    public void Constructor(IInputService inputService)
    {
        inputService.OnMoveDirectionChange += Move;
        inputService.OnMouseMovement += Rotate;
    }

    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void Move(Vector3 direction)
    {
        Vector3 localDirection = transform.TransformDirection(direction);
        localDirection.y = 0;
        localDirection = localDirection.normalized;
        transform.position += _speed * Time.deltaTime * localDirection;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}