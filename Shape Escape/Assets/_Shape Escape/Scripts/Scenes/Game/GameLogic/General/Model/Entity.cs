using UniRx;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General
{
    public abstract class Entity : IEntity
    {
        private readonly ReactiveProperty<Team> _team = new();
        public IReadOnlyReactiveProperty<Team> TeamId => _team;

        public Entity(Team team)
        {
            SetTeam(team);
        }

        public Entity()
        {
            SetTeam(Team.White);
        }

        public void SetTeam(Team team)
        {
            _team.Value = team;
        }
    }
}