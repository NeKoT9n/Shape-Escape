using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine.States;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.GameStateMachine
{
    public class GameStateMachine : Zenject.ITickable
    {
        private List<IState> _states;
        private IState _currentState;

        private ITickableState _tickable;

        public void Initialize(IEnumerable states)
        {
            _states = (List<IState>)states;
        }

        public void SwitchState<TState>() where TState : IState
        {
            IState state = _states.OfType<TState>().FirstOrDefault();

            if (_currentState == state)
                return;

            _currentState?.Exit();
            _currentState = state;
            _tickable = _currentState as ITickableState;
            _currentState.Enter();


        }

        public void Tick()
        {
            _tickable?.Tick();
        }
    }
}