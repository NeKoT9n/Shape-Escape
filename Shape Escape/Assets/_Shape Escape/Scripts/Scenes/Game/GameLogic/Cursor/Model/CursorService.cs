using Assets._Shape_Escape.Scripts.Addressable.Containers;
using Assets._Shape_Escape.Scripts.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Data;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using UniRx;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Cursor.Model
{
    public class CursorService : IReadOnlyCursor, IInitializable
    {
        public IReadOnlyReactiveProperty<Team> CurrentTeam => _cursor.TeamId;
        public CursorData CursorData => _cursor.CursorData;

        private readonly ScriptableObjectContainer _dataContainer;
        private CursorModel _cursor;
        private Camera _camera = Camera.main;


        public CursorService(ScriptableObjectContainer dataContainer)
        {
            _dataContainer = dataContainer;
        }

        public void Initialize()
        {
            CursorData data = _dataContainer.GetScriptableObject<CursorData>();
            _cursor = new(data);
        }

        public void Death()
        {
            _cursor.Death();
        }


   


    }
}