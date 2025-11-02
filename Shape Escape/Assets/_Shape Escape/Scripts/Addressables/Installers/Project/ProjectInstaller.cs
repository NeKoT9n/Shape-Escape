using Assets._Shape_Escape.Scripts.Addressable.Providers.AssetProvider;
using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model;
using Zenject;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AddressableAssetProvider>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputService>().AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<ScriptableObjectContainer>().AsSingle();
        Container.BindInterfacesTo<SceneLoader>().AsSingle().NonLazy();

        Container.Bind<CursorService>().AsSingle();
    }
}