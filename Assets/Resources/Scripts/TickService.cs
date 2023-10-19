using System;
using UnityEngine;

public class TickService : MonoBehaviour, ITickService
{
    public event Action OnTick;
    private void Update() => OnTick?.Invoke();
}