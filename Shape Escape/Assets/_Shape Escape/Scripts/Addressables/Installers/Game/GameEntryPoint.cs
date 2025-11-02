using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.Factories;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Addressable.Installers.Game
{
    public class GameEntryPoint : MonoBehaviour
    {

        [Inject] private GameStateMachine _gameStateMachine;
        [Inject] private GameStateFactory _stateFactory;

        
        private void Awake()
        {
            List<IState> states = new()
            {
                _stateFactory.CreateState<InitializeState>(),
                _stateFactory.CreateState<StartState>(),
                _stateFactory.CreateState<PlayGameState>(),
                _stateFactory.CreateState<PauseState>(),
            };

            _gameStateMachine.Initialize(states);
            _gameStateMachine.SwitchState<InitializeState>();
        }

    }
}