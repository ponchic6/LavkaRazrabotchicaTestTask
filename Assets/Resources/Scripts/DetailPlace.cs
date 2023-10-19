using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))] 
public class DetailPlace : MonoBehaviour, IDetailPlace
{
    [SerializeField] private Detail _necesseryDetail;
    [SerializeField] private Material _originalDetailMaterial;
    private MeshRenderer _meshRenderer;
    private bool _hasDetail = false;
    private DetailPlace _parentDetailPlace;
    public void Show()
    {
        _meshRenderer.enabled = true;
    }

    public void Hide()
    {
        _meshRenderer.enabled = false;
    }

    public IDetail GetNecesseryDetail()
    {
        return _necesseryDetail;
    }

    public void SetNecesseryDetailMaterial()
    {
        GetComponent<Renderer>().material = _originalDetailMaterial;
        _hasDetail = true;
    }
    
    public bool HasParent()
    {
        if (transform.parent.TryGetComponent(out _parentDetailPlace) && _parentDetailPlace.HasDetail())
        {
            return true;
        }
        
        if (transform.parent == transform.root)
        {
            return true;
        }

        return false;
    }

    public bool HasDetail()
    {
        return _hasDetail;
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
    }

    private void Update()
    {
        if (!_hasDetail)
        {
            Hide();
        }
    }
}