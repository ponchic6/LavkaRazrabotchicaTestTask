using UnityEngine;

public interface IDetailTaker
{
    public void TakeDetail();
    public bool IsDetailTaken();
    public IDetail GetCurrentTakenDetail();

}