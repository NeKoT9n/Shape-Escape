using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Teams;
using UnityEngine;
using UniRx;
using System;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.CursorStates;
using Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model.Drag;

public class CursorPresentor : IInitializable, IDisposable
{
    private readonly IReadOnlyCursor _cursor;
    private readonly TeamColorContainer _teamService;
    private readonly CursorView _view;
    private readonly IInputService _inputService;
    private readonly IDragService _dragService;

    private CursorStateMachine _stateMachine;
    private CursorInteractionService _interactionService;

    private readonly CompositeDisposable _disposables = new();

    public CursorPresentor(
        IReadOnlyCursor cursor,
        TeamColorContainer teamService,
        CursorView cursorView,
        IInputService inputService,
        IDragService dragService)
    {
        _cursor = cursor;
        _teamService = teamService;
        _view = cursorView;
        _inputService = inputService;
        _dragService = dragService;
    }

    public void Initialize()
    {
        _view.Initialize(_cursor.CursorData);
        SetColor(_cursor.CurrentTeam.Value);

        _interactionService = new(_view.interactablesMask);
        _interactionService.Initialize();

        _stateMachine = new(new ICursorState[]
        {
            new CursorDefaultState(_view, _interactionService),
            new CursorHoverState(_view, _interactionService),
            new CursorClickState(_view, _dragService, _inputService, _interactionService),
            new CursorDraggingState(_dragService, _inputService)
        }); //TODO: Add to Zenject Binding


        _view.Colided += OnColided;
        _cursor.CurrentTeam.Subscribe(value => SetColor(value)).AddTo(_disposables);

        _inputService.OnLeftClickDown
            .WithLatestFrom(_interactionService.CurrentInteractable, (_, target) => target)
            .Where(target => target != null)
            .Subscribe(target =>
            {
                target.OnInteract();
                _stateMachine.ChangeState(CursorStateType.Click);
            }).AddTo(_disposables);

        _inputService.MouseWorldPosition
            .Subscribe(position => _view.SetPositionWithOffset(position))
            .AddTo(_disposables);
    }

    public void SetColor(Team team)
    {
        _view.SetColor(_teamService.GetColorBy(team));
    }

    private void OnColided(Team team)
    {
        if (_cursor.CurrentTeam.Value == team)
            return;

        _cursor.Death();
        _view.SetVisable(false);
    }

    public void Dispose()
    {
        _view.Colided -= OnColided;
        _disposables.Dispose();
    }
}
