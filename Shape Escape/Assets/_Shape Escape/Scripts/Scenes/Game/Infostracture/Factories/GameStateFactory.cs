using Zenject;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.Infostracture.Factories
{
    public class GameStateFactory 
    {
        private readonly DiContainer _diContainer;

        public GameStateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TState CreateState<TState>() where TState : IState
        {
            return _diContainer.Instantiate<TState>();
        }
    }
}