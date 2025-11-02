using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model
{
    public interface IReadOnlyCursor
    {
        public IReadOnlyReactiveProperty<Team> CurrentTeam { get; }
        public CursorData CursorData { get; }
        public void Death();
    }
}