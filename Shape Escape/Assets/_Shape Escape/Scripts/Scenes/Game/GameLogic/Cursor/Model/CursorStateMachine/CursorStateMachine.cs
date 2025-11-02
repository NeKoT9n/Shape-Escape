using System;
using System.Collections.Generic;
using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates
{
    public class CursorStateMachine : IDisposable
    {
        private readonly Dictionary<CursorStateType, ICursorState> _states;
        private ICursorState _currentState;

        private ReactiveProperty<CursorStateType> _currentStateType { get; } = new(CursorStateType.Default);
        public IReadOnlyReactiveProperty<CursorStateType> CurrentState => _currentStateType;

        public CursorStateMachine(IEnumerable<ICursorState> states)
        {
            _states = new Dictionary<CursorStateType, ICursorState>();
            foreach (var state in states)
            {
                _states[state.Type] = state;
                state.StateChangeRequest += ChangeState;
            }

                ChangeState(CursorStateType.Default);
        }

        public void ChangeState(CursorStateType newState)
        {
            if (_currentState != null && _currentState.Type == newState)
                return;

            _currentState?.Exit();
            _currentState = _states[newState];
            _currentState.Enter();
            _currentStateType.Value = newState;
        }

        public void Dispose()
        {
            foreach(var state in _states.Values)
            {
                state.StateChangeRequest -= ChangeState;
            }
        }
    }
}
