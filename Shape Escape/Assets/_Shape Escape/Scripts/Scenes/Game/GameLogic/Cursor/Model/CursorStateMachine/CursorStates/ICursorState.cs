using System;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates
{
    public interface ICursorState
    {
        public CursorStateType Type { get; }
        public event Action<CursorStateType> StateChangeRequest;
        void Enter();
        void Exit();
    }
}
