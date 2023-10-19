using UnityEngine;

public interface IDetail
{
    public void Take(Transform detailTransferPoint);
    public void Drop();
    public void DestroyDetail();
}