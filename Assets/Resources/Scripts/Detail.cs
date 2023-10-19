using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Detail : MonoBehaviour, IDetail
{
    private Rigidbody _rigidbody;
    private Transform _currentPos;
    public void Take(Transform detailTransferPoint)
    {
        _currentPos = detailTransferPoint;
        _rigidbody.isKinematic = true;
    }

    public void Drop()
    {
        _currentPos = transform;
        _rigidbody.isKinematic = false;
    }

    public void DestroyDetail()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentPos = transform;
    }

    private void Update()
    {
        transform.position = _currentPos.position;
        transform.rotation = _currentPos.rotation;
    }
}