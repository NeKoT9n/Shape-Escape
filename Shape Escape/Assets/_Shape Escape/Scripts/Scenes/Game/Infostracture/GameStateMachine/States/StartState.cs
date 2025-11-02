using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Model;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States.StatesObservers;
using System.Collections.Generic;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States
{
    public class StartState : IState
    {
        [Inject] private readonly List<IStartGameObserver> _observers;
        [Inject] private readonly ShapeService _shapeService;
        [Inject] private readonly GameStateMachine _gameStateMachine;
        [Inject] private readonly ScriptableObjectContainer _scriptableObjectContainer;

        public void Enter()
        {
            foreach(var observer in _observers)
            {
                observer.OnGameStarted();
            }

            

            _gameStateMachine.SwitchState<PlayGameState>();
        }

        public void Exit()
        {
            
        }

    }
}