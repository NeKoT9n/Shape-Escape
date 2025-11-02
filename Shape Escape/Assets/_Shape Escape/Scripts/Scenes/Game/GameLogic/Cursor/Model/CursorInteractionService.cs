using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Interactables;
using System;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model
{
    public class CursorInteractionService : IInitializable, IDisposable
    {
        private readonly Camera _camera = Camera.main;
        private readonly ReactiveProperty<IInteractable> _current = new();
        private LayerMask _interactables;

        private CompositeDisposable _disposables = new();

        public IReadOnlyReactiveProperty<IInteractable> CurrentInteractable => _current;

        public CursorInteractionService(LayerMask interactables)
        {
            _interactables = interactables;
        }
        public void Initialize()
        {
            _ = Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0;
                    Collider2D hit = Physics2D.OverlapPoint(mousePosition, _interactables);

                    IInteractable interactable = hit != null ? hit.GetComponent<IInteractable>() : null;

                    if (_current.Value == interactable)
                        return;

                    if (interactable != _current.Value)
                        _current.Value?.OnHoverExit();

                    interactable?.OnHoverEnter();

                    _current.Value = interactable;
                })
                .AddTo(_disposables);
        }

        public void Interact()
        {
            _current.Value?.OnInteract();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}
