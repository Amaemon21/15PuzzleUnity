using UnityEngine;
using Zenject;

public class MoveCountInstaller : MonoInstaller
{
    [SerializeField] private MoveCountView _moveCountView;

    public override void InstallBindings()
    {
        Container.Bind<MoveCountView>().FromInstance(_moveCountView).AsSingle().NonLazy();
    }
}