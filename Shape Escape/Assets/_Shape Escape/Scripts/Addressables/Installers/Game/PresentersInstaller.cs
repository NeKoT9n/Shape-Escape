
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Lazers.View;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Presentor;
using UnityEngine;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Addressable.Installers.Game
{
    public class PresentersInstaller : MonoInstaller
    {
        [SerializeField] private CursorView _cursorView;
        [SerializeField] private Transform _shapesParent;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CursorPresentor>()
                .AsCached()
                .WithArguments(_cursorView)
                .NonLazy();
            
            Container
                .BindInterfacesTo<ShapeContainerPresentor>()
                .AsCached()
                .WithArguments(_shapesParent)
                .NonLazy();

        }

    }
}