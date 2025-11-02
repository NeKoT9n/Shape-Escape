using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Interactables;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using System;
using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates
{
    public class CursorClickState : ICursorState
    {
        public CursorStateType Type => CursorStateType.Click;

        private readonly CursorView _view;
        private readonly IDragService _dragService;
        private readonly IInputService _input;
        private readonly IReadOnlyReactiveProperty<IInteractable> _currentHover;

        public event Action<CursorStateType> StateChangeRequest;

        public CursorClickState(
            CursorView view,
            IDragService dragService,
            IInputService inputService,
            CursorInteractionService interaction
            )
        {

            _view = view;
            _dragService = dragService;
            _input = inputService;
            _currentHover = interaction.CurrentInteractable;
        }


        public void Enter()
        {
            _view.SetClickedIcon();

            if (_currentHover.Value is IDraggable draggable)
            {
                _dragService.StartDrag(draggable);
                StateChangeRequest?.Invoke(CursorStateType.Dragging);
            } // TODO: Add Strategy patern
            else
            {
                StateChangeRequest?.Invoke(CursorStateType.Default);
            }
        }

        public void Exit() { }

    }
}
