using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using System;
using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates
{
    public class CursorDraggingState : ICursorState
    {
        private readonly IDragService _dragService;
        private readonly IInputService _input;

        private readonly CompositeDisposable _disposable = new();

        public event Action<CursorStateType> StateChangeRequest;

        public CursorStateType Type => CursorStateType.Dragging;

        public CursorDraggingState(
            IDragService dragService,
            IInputService inputService)
        {
            _dragService = dragService;
            _input = inputService;
        }

        public void Enter()
        {
            _input.OnLeftClickUp
           .Subscribe(_ =>
           {              
               StateChangeRequest?.Invoke(CursorStateType.Default);
           })
           .AddTo(_disposable);
        }

        public void Exit()
        {
            _dragService.EndDrag();
            _disposable.Clear();
        }
    }
}
