using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Teams
{
    public class TeamColorContainer : IInitializable
    {

        private readonly ScriptableObjectContainer _container;

        private Dictionary<Team, ColorTeam> _teams;
        

        public TeamColorContainer(ScriptableObjectContainer container)
        {
            _container = container;
            
        }

        public void Initialize()
        {
            var teamList = _container.GetScriptableObject<TeamsData>().Teams;
            _teams = new(teamList.Count);

            foreach (var team in teamList)
            {
                _teams.Add(team.Team, team);
            }
        }

        public Color GetColorBy(Team team)
        {
            return _teams[team].Color;
        }
    }
}
