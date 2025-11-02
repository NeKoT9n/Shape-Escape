using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Teams;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.Factories;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        Container.Bind<GameStateFactory>().AsSingle();

        Container.BindInterfacesAndSelfTo<WorldViewContainer>().AsSingle();
        Container.Bind<WorldFactory>().AsSingle();
        Container.Bind<ShapeSpawner>().AsSingle();

        Container.BindInterfacesTo<CursorService>().AsSingle();
        Container.BindInterfacesTo<DragService>().AsSingle();

        Container.BindInterfacesAndSelfTo<TeamColorContainer>().AsSingle();
        Container.BindInterfacesAndSelfTo<ShapeFactory>().AsSingle();
        Container.Bind<ShapeService>().AsSingle();
    }
}