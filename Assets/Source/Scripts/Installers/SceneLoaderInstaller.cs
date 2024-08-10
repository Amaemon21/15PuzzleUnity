using Zenject;

public class SceneLoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneLoadingService>().FromNew().AsSingle();  
    }
}