using Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.General;
using System;
using UnityEngine;

namespace Assets._Shape_Escape.Scripts.Scenes.Game.GameLogic.Shape
{
    public class Shape : Entity
    {
        public event Action<Shape> Died;
        public ShapeData ShapeData => _shapeData;
        public Vector2 StartPosition => _startPosition;
        private readonly ShapeData _shapeData;
        private Vector2 _startPosition;

        public Shape(ShapeData shapeData)
        {
            _shapeData = shapeData;
        }

        public void SetStartPosition(Vector2 startPosition)
        {
            _startPosition = startPosition;
        }

        public void Death()
        {
            Debug.Log("Died");
            Died?.Invoke(this);
        }
    }
}