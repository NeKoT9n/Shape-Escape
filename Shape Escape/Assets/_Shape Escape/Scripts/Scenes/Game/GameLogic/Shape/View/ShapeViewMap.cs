using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General.View;
using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape.View
{
    public class ShapeViewMap : IEntityView
    { 

        private readonly Dictionary<ShapeType, ShapeView> _map;

        public ShapeViewMap(Dictionary<ShapeType, ShapeView> map)
        {
            _map = map;
        }

        public GameObject GameObject => throw new NotImplementedException();

        public event Action<Team> Colided;

        public IEntityView Get(ShapeType type)
        {
            if (_map.TryGetValue(type, out var view))
                return view;

            return null;
        }

        public void SetColor(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
