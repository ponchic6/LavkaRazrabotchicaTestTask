using System;
using UnityEngine;
using Zenject;

public class DetailPlacePlaceChecker : MonoBehaviour, IDetailPlaceChecker
{    
    private Vector2 _screenCenter;
    private Ray _cameraRay;
    private RaycastHit _hit;
    private IDetailPlace _currentDetailPlace;
    private IDetailTaker _detailTaker;
    
    [Inject]
    public void Constructor(IDetailTaker detailTaker)
    {
        _detailTaker = detailTaker;
    }
    
    public void CheckDetail()
    {
        _cameraRay = Camera.main.ScreenPointToRay(_screenCenter);

        if (Physics.Raycast(_cameraRay, out _hit) && _hit.collider.TryGetComponent(out _currentDetailPlace))
        {
            if (_detailTaker.IsDetailTaken() &&
                _currentDetailPlace.GetNecesseryDetail() == _detailTaker.GetCurrentTakenDetail())
            {
                _currentDetailPlace.Show();
            }
        }
        
    }

    private void Start()
    {
        _screenCenter = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    private void Update()
    {
        CheckDetail();
    }
}