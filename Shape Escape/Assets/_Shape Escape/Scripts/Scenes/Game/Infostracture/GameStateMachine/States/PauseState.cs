using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States.StatesObservers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States
{
    public class PauseState : IState
    {
        [Inject] private readonly List<IPauseGameObserver> _observers;

        public void Enter()
        {
            foreach(var observer in _observers)
            {
                observer.OnGamePaused();
            }
        }

        public void Exit()
        {
            foreach (var observer in _observers)
            {
                observer.OnGameResumed();
            }
        }
    }
}