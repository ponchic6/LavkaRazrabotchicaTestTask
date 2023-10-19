using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private TickService _tickService;
    [SerializeField] private DetailTaker _detailTaker;
    
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterDetailTaker();
    }

    private void RegisterDetailTaker()
    {
        Container.Bind<IDetailTaker>().FromInstance(_detailTaker).AsSingle();
    }

    private void RegisterInputService()
    {
        IInputService inputService = Container.Instantiate<InputService>();
        Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
    }

    private void RegisterTickService()
    {
        Container.Bind<ITickService>().FromInstance(_tickService).AsSingle();
    }
}
