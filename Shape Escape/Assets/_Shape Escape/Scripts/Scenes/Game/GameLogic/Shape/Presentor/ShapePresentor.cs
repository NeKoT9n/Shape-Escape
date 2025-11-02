using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Teams;
using System;
using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Presentor
{
    public class ShapePresentor : IInitializable, IDisposable
    {
        private readonly Shape _shape;
        private readonly TeamColorContainer _teamColors;
        private readonly ShapeView _view;

        private readonly CompositeDisposable _disposables = new();

        public ShapePresentor(Shape shape,TeamColorContainer teamColorContainer, ShapeView view)
        {
            _shape = shape;
            _teamColors = teamColorContainer;
            _view = view;
        }

        public void Initialize()
        {
            _view.Initialize();
            SetColor(_shape.TeamId.Value);

            _shape.TeamId
                .Subscribe(team => SetColor(team))
                .AddTo(_disposables);

            _view.Colided += OnColided;
        }

        private void SetColor(Team team)
        {
            _view.SetColor(_teamColors.GetColorBy(team));
        }

        private void OnColided(Team team)
        {
            if (_shape.TeamId.Value == team)
                return;

            _view.gameObject.SetActive(false);  
            _shape.Death();
        }

        public void Dispose()
        {
            _view.Colided -= OnColided;
        }
    }
}
