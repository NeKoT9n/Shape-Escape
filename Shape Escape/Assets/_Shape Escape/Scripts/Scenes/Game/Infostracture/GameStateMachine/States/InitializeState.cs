using Assets._Shape_Escape.Scripts.General;
using System.Collections.Generic;
using Zenject;


namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States
{
    public class InitializeState : IState
    {

        [Inject] private readonly List<IAsyncInitializable> _asyncInitializables;
        [Inject] private readonly List<General.IInitializable> _initializables;
        [Inject] private readonly GameStateMachine _gameStateMachine;
        public async void Enter()
        {
            foreach(var asynInit in _asyncInitializables)
            {
                await asynInit.Initialize();
            }

            foreach (var init in _initializables)
            {
                init.Initialize();
            }

            _gameStateMachine.SwitchState<StartState>();
        }

        public void Exit() { }
    }
}