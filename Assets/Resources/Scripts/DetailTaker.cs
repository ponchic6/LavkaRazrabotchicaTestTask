using System;
using UnityEngine;
using Zenject;

public class DetailTaker : MonoBehaviour, IDetailTaker
{
    [SerializeField] private Transform _transferPoint;
    private Vector2 _screenCenter;
    private Ray _cameraRay;
    private RaycastHit _hit;
    private bool _isDetailTaken = false;
    private IDetail _currentDetail;
    private IDetailPlace _currentDetailPlace;
        
    [Inject]
    public void Constructor(IInputService inputService)
    {
        inputService.OnButtonTakeClick += TakeDetail;
    }

    public void TakeDetail()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_screenCenter);

        if (Physics.Raycast(_cameraRay, out _hit))
        {
            switch (_isDetailTaken)
            {
                case true:
                    if (_hit.collider.TryGetComponent(out _currentDetailPlace) &&
                        _currentDetail == _currentDetailPlace.GetNecesseryDetail() && _currentDetailPlace.HasParent())
                    {
                        _currentDetailPlace.SetNecesseryDetailMaterial();
                        _currentDetail.DestroyDetail();
                    }

                    else
                    {
                        _currentDetail.Drop();
                    }

                    _isDetailTaken = false;
                    break;
                
                case false:
                    if (_hit.collider.TryGetComponent(out _currentDetail))
                    {
                        _currentDetail.Take(_transferPoint);
                        _isDetailTaken = true;
                    }
                    break;
            }
        }
    }

    public bool IsDetailTaken()
    {
        return _isDetailTaken;
    }

    public IDetail GetCurrentTakenDetail()
    {
        if (_isDetailTaken)
            return _currentDetail;
        return null;
    }

    private void Start()
    {
        _screenCenter = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }
    
}