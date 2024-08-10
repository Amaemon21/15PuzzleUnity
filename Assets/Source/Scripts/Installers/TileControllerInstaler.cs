using UnityEngine;
using Zenject;

public class TileControllerInstaler : MonoInstaller
{
    [SerializeField] private TilesController _tilesController;

    public override void InstallBindings()
    {
        Container.Bind<TilesController>().FromInstance(_tilesController).AsSingle().NonLazy();
    }
}
