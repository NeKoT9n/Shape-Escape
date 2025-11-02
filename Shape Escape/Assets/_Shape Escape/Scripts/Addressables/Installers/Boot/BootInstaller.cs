using Assets._Shape_Escape.Scripts.General;
using Zenject;

public class BootInstaller : MonoInstaller
{
    [Inject] private readonly ISceneLoader _sceneLoader;
    public override void InstallBindings()
    {
        _sceneLoader.LoadGameScene();
    }
}