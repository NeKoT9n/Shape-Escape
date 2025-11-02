using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates
{
    public class CursorDefaultState : ICursorState
    {
        private readonly CursorView _view;
        private readonly CursorInteractionService _cursorInteractionService;

        private CompositeDisposable _disposables = new();

        public event Action<CursorStateType> StateChangeRequest;

        public CursorStateType Type => CursorStateType.Default;

        public CursorDefaultState(CursorView view, CursorInteractionService cursorInteractionService)
        {
            _view = view;
            _cursorInteractionService = cursorInteractionService;
        }

        public void Enter()
        {
            _view.SetDefaultIcon();

            Debug.Log(_cursorInteractionService.CurrentInteractable.Value);

            _cursorInteractionService.CurrentInteractable
                .Where(target => target != null)
                .Subscribe(_ => StateChangeRequest?.Invoke(CursorStateType.Hover))
                .AddTo(_disposables);
        }

        public void Exit()
        {
            _disposables.Clear();
        }
    }
}
