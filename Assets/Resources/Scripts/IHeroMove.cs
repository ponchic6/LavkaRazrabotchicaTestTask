using UnityEngine;

public interface IHeroMove
{
    public void Move(Vector3 direction);
    public void Rotate(Quaternion rotation);
}