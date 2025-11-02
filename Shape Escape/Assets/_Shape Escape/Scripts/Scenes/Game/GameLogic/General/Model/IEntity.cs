using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General
{
    public interface IEntity 
    {
        public IReadOnlyReactiveProperty<Team> TeamId { get; }
    }
}